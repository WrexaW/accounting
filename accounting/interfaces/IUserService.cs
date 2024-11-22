using accounting.entities;

namespace accounting.interfaces
{
    public interface IUserService
    {
        public UserEntity Create(UserEntity user);

        public List<UserEntity> GetAll();

        public int RemainDays(int id);
    }
}
