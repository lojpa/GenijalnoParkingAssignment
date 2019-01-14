using GenijalnoParkingAssignment.Models;
using GenijalnoParkingAssignment.Repositories;
using GenijalnoParkingAssignment.Services;
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
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerService.Get(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpGet]
        public async Task<ActionResult<Customer>> GetCustomers()
        {


            var customers = await _customerService.GetAll();

            return Ok(customers);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer op)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var createdCustomer = await _customerService.Create(op);
            return Ok(createdCustomer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            await _customerService.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Customer>> UpdateCustomer(Customer customer)
        {
            var updatedCustomer = await _customerService.Update(customer);
            return Ok(updatedCustomer);
        }
    }
}
