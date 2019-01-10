using GenijalnoParkingAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenijalnoParkingAssignment.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> Get(int id);
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> Create(Customer customer);
        Task<Customer> Update(Customer customer);
        Task Delete(int id);
    }
}
