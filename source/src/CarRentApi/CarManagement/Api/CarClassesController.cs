using Microsoft.AspNetCore.Mvc;
using CarRentApi.Common;

namespace CarRentApi.CarManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarClassesController : Controller
    {
        private readonly RepoBase<CarClass> repo;

        public CarClassesController()
        {
            repo = new RepoBase<CarClass>();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var foundedEntities = repo.GetById(id);
            return foundedEntities == null ? NotFound() : Ok(repo.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CarClass entity)
        {
            entity.Id = 0;
            return Created("api/[controller]", repo.Add(entity));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CarClass entity)
        {
            entity.Id = id;

            var entityToUpdate = repo.GetById(id);
            if (entityToUpdate == null)
            {
                return NotFound();
            }
            return Ok(repo.Update(entity));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entityToDelete = repo.GetById(id);
            if (entityToDelete == null)
            {
                return NotFound();
            }
            repo.Delete(entityToDelete);
            return Ok();
        }
    }
}
