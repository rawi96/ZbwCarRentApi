using Microsoft.AspNetCore.Mvc;
using CarRentApi.CarManagement.Application;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;

namespace CarRentApi.CarManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        private readonly CarService _service;
        private readonly IMapper _mapper;

        public CarsController(CarService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(MapToResponseDto(_service.GetAll()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var entity = _service.GetById(id);
            
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(MapToResponseDto(entity));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CarRequestDto entity)
        {
            //TODO: If the user tries to set a invalid carClassId return a HTTP 400.
            var dbObject = _service.Add(MapToDbObject(entity));
            return Created("api/cars/" + dbObject.Id, MapToResponseDto(dbObject));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CarRequestDto entity)
        {
            //TODO: If the user tries to set a invalid carClassId return a HTTP 400.
            var entityToUpdate = _service.GetById(id);
            
            if (entityToUpdate == null)
            {
                return NotFound();
            }
            
            var dbObject = MapToDbObject(entity);
            dbObject.Id = id;
            return Ok(_service.Update(dbObject));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entityToDelete = _service.GetById(id);
            if (entityToDelete == null)
            {
                return NotFound();
            }
            _service.Delete(entityToDelete);
            return Ok();
        }

        private IEnumerable<CarResponseDto> MapToResponseDto(IEnumerable<Car> list)
        {
            return list.Select(entity => _mapper.Map<CarResponseDto>(entity)).ToList();
        }

        private CarResponseDto MapToResponseDto(Car entity)
        {
            return _mapper.Map<CarResponseDto>(entity);
        }

        private Car MapToDbObject(CarRequestDto entity)
        {
            return _mapper.Map<Car>(entity);
        }
    }
}
