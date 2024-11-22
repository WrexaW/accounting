using accounting.Dtos.Packages;
using accounting.entities;
using accounting.interfaces;
using accounting.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace accounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private IPackageService _service;

        public PackageController(IPackageService service)
        {
            _service = service;
        }
        [HttpGet("get-counter")]
        public int getCounter() => _service.Counter;
        [HttpGet]
        public List<PackageEntity> GetAll() => _service.GetAll();
        [HttpGet("{id}")]
        public PackageEntity Get(int id) => _service.Get(id);

        [HttpPost]
        public PackageEntity Post([FromBody] CreateDto input) => _service.Creat(input);
        [HttpPut]
        public PackageEntity Put([FromBody] UpdateDto input) => _service.Update(input);
        [HttpPatch("update-status/{id}")]
        public bool UpdateStatus(int id) => _service.ChaneStatus(id);
        [HttpPatch("update-order/{id}")]
        public bool UpdateOrder(int id, int order) => _service.Chabgeorder(id, order);
        [HttpDelete("{id}")]
        public bool Delete(int id) => _service.Delete(id);
        [HttpPost("buy/{packageId}")]
        public UserPackageEntity Buy(int userId, int packageId, string transaction="") =>_service.Buy(userId,packageId,transaction);


    }
}
