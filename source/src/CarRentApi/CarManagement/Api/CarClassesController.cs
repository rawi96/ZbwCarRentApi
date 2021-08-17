using Microsoft.AspNetCore.Mvc;
using CarRentApi.Common;
using CarRentApi.CarManagement.Application;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;

namespace CarRentApi.CarManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarClassesController : Controller
    {
        private readonly CarClassService _service;
        private readonly IMapper _mapper;

        public CarClassesController(CarClassService service, IMapper mapper)
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
        public IActionResult Post([FromBody] CarClassRequestDto entity)
        {
            var dbObject = _service.Add(MapToDbObject(entity));
            return Created("api/carclasses/" + dbObject.Id, _service.Add(MapToDbObject(entity)));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CarClassRequestDto entity)
        {
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

        private IEnumerable<CarClassResponseDto> MapToResponseDto(IEnumerable<CarClass> list)
        {
            return list.Select(entity => _mapper.Map<CarClassResponseDto>(entity)).ToList();
        }

        private CarClassResponseDto MapToResponseDto(CarClass entity)
        {
            return _mapper.Map<CarClassResponseDto>(entity);
        }

        private CarClass MapToDbObject(CarClassRequestDto entity)
        {
            return _mapper.Map<CarClass>(entity);
        }
    }
}
