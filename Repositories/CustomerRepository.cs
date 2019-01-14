using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenijalnoParkingAssignment.Context;
using GenijalnoParkingAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace GenijalnoParkingAssignment.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly GenijalnoParkingContext _genijalnoParkingContext;

        public CustomerRepository(GenijalnoParkingContext genijalnoParkingContext)
        {
            _genijalnoParkingContext = genijalnoParkingContext;
        }

        public async Task<Customer> Create(Customer customer)
        {
            _genijalnoParkingContext.Customers.Add(customer);

            await _genijalnoParkingContext.SaveChangesAsync();
            return customer;
        }

        public async Task Delete(int id)
        {
            var customer = await _genijalnoParkingContext.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (customer != null)
            {
                _genijalnoParkingContext.Customers.Remove(customer);
                await _genijalnoParkingContext.SaveChangesAsync();
            }

        }

        public async Task<Customer> Get(int id)
        {
            var customer = await _genijalnoParkingContext.Customers.Include(pd => pd.ParkingDetails).Include(v => v.Vehicle).FirstOrDefaultAsync(x => x.Id == id);

            if (customer == null)
                return null;

            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = await _genijalnoParkingContext.Customers.Include(pd => pd.ParkingDetails).Include(v => v.Vehicle).ToListAsync();

            return customers;
        }

        public async Task<Customer> Update(Customer customer)
        {
            _genijalnoParkingContext.Customers.Update(customer);

            await _genijalnoParkingContext.SaveChangesAsync();
            return customer;
        }
    }
}
