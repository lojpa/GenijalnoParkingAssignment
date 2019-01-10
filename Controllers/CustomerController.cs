using GenijalnoParkingAssignment.Models;
using GenijalnoParkingAssignment.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenijalnoParkingAssignment.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerRepository.Get(id);
            if (customer == null)
                return NotFound();
            return Ok(new { customer });
        }

        [HttpGet]
        public async Task<ActionResult<Customer>> GetCustomers()
        {
            var customers = await _customerRepository.GetAll();

            return Ok(new { customers });
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer op)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var createdCustomer = await _customerRepository.Create(op);
            return Ok(createdCustomer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            await _customerRepository.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer(Customer customer)
        {
            var updatedCustomer = await _customerRepository.Update(customer);
            return Ok(updatedCustomer);
        }
    }
}
