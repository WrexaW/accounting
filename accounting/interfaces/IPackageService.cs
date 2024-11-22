using accounting.Dtos.Packages;
using accounting.entities;

namespace accounting.interfaces
{
    public interface IPackageService
    {
        public int Counter { get; set; }
        public PackageEntity Creat(CreateDto input);

        public PackageEntity Update(UpdateDto input);

        public bool Chabgeorder(int id, int orderId);

        public bool ChaneStatus(int id);

        public bool Delete(int id); 

        public PackageEntity Get(int id);

        public List<PackageEntity> GetAll();

        public UserPackageEntity Buy(int userId, int packageId, string transaction);

        //public int RemainAccountTime(int userId);





    }
}
