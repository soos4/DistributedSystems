using elosztott_gyak.Model;
using elosztott_gyak.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace elosztott_gyak.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        [HttpGet(Name = nameof(GetCar))]
        public async Task<Car> GetCar([FromHeader] string licensePlate)
        {
            return await CarDb.GetInstance().GetCar(licensePlate);
        }

        [HttpPost(Name = nameof(AddCar))]
        public async Task<Car> AddCar([FromBody] Car car)
        {
            return await CarDb.GetInstance().AddCar(car);
        }
    }
}