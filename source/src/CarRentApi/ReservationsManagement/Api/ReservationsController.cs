using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using CarRentApi.ReservationManagement.Application;

namespace CarRentApi.ReservationManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : Controller
    {
        private readonly ReservationService _service;
        private readonly IMapper _mapper;

        public ReservationsController(ReservationService service, IMapper mapper)
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
        public IActionResult Post([FromBody] ReservationRequestDto entity)
        {
            //TODO: If the user tries to set a invalid customerId or carId return a HTTP 400.
            var dbObject = _service.Add(MapToDbObject(entity));
            return Created("api/reservations/" + dbObject.Id, dbObject);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ReservationRequestDto entity)
        {
            //TODO: If the user tries to set a invalid customerId or carId return a HTTP 400.
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

        private IEnumerable<ReservationResponseDto> MapToResponseDto(IEnumerable<Reservation> list)
        {
            return list.Select(entity => _mapper.Map<ReservationResponseDto>(entity)).ToList();
        }

        private ReservationResponseDto MapToResponseDto(Reservation entity)
        {
            return _mapper.Map<ReservationResponseDto>(entity);
        }

        private Reservation MapToDbObject(ReservationRequestDto entity)
        {
            return _mapper.Map<Reservation>(entity);
        }
    }
}
