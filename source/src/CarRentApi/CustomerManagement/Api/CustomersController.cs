using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using CarRentApi.CustomerManagement.Application;

namespace CarRentApi.CustomerManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly CustomerService _service;
        private readonly IMapper _mapper;

        public CustomersController(CustomerService service, IMapper mapper)
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
        public IActionResult Post([FromBody] CustomerRequestDto entity)
        {
            var dbObject = _service.Add(MapToDbObject(entity));
            return Created("api/customers/" + dbObject.Id, dbObject);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerRequestDto entity)
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
            //TODO: If the user tries to delete a Customer which still has reservations return a HTTP 400.
            var entityToDelete = _service.GetById(id);
            if (entityToDelete == null)
            {
                return NotFound();
            }
            _service.Delete(entityToDelete);
            return Ok();
        }

        private IEnumerable<CustomerResponseDto> MapToResponseDto(IEnumerable<Customer> list)
        {
            return list.Select(entity => _mapper.Map<CustomerResponseDto>(entity)).ToList();
        }

        private CustomerResponseDto MapToResponseDto(Customer entity)
        {
            return _mapper.Map<CustomerResponseDto>(entity);
        }

        private Customer MapToDbObject(CustomerRequestDto entity)
        {
            return _mapper.Map<Customer>(entity);
        }
    }
}
