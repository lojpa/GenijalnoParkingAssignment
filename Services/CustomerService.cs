using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenijalnoParkingAssignment.Models;
using GenijalnoParkingAssignment.Repositories;

namespace GenijalnoParkingAssignment.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Create(Customer customer)
        {
            var createdCustomer = await _customerRepository.Create(customer);
            return createdCustomer;
        }

        public async Task Delete(int id)
        {
            await _customerRepository.Delete(id);
        }

        public async Task<Customer> Get(int id)
        {
            var customer = await _customerRepository.Get(id);
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = await _customerRepository.GetAll();
            return customers;
        }

        public async Task<Customer> Update(Customer customer)
        {
            var updatedCustomer = await _customerRepository.Update(customer);
            return updatedCustomer;
        }
    }
}
