using accounting.entities;
using accounting.interfaces;

namespace accounting.Service
{
    public class UserService : IUserService
    {
        private AccountinigDbContext _context = new AccountinigDbContext();

        public UserEntity Create(UserEntity user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            { 
            }
            return user;
        }

        public List<UserEntity> GetAll() => _context.Users.OrderByDescending(x => x.Id).ToList();

        public int RemainDays(int id)
        {
            int result = 0;
            try
            {
                UserEntity user = _context.Users.FirstOrDefault(x => x.Id == id && x.Expiredate.HasValue && x.Expiredate.Value>DateTime.Now);
                if (user != null)
                {
                    result = (int)(user.Expiredate.Value - DateTime.Now).TotalDays;
                }
            }
            catch (Exception ex)
            { 
            }
            return result;
        }
    }
}
