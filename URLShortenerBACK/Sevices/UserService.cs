using URLShortenerBACK.Models;
using URLShortenerBACK.DTO;
using Microsoft.EntityFrameworkCore;

namespace URLShortenerBACK.Sevices
{
    public class UserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }
        public async Task<User> RegisterUser(User newUser)
        {
            var res = await _context.Users.FindAsync(newUser.Id);
            if (res == null)
            {
                this._context.Users.Add(newUser);
                this._context.SaveChanges();
            }
            return newUser;
        }
        public async Task<IEnumerable<User>> GetUsers(){
            var users = _context.Users;
            return users;
        }
        public async Task<User?> LoginUser(UserLogin user)
        {
            //прикрутить через jwt (вибрать правильно кодування, звірити з лібою ангуляру)
            var res = (from el in _context.Users where el.Name==user.Name select el).ToList();//змінити як додам унікальність імен
            if (res.Count==0)
            {
                return null;
            }
            var account = res[0];
            if (account.Password == user.Password)  return account;
            return null;
        }
    }
}
