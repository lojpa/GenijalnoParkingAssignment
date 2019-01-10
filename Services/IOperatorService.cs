using GenijalnoParkingAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenijalnoParkingAssignment.Services
{
    public interface IOperatorService
    {
        Task<Operator> Get(int id);
        Task<IEnumerable<Operator>> GetAll();
        Task<Operator> Create(Operator op);
        Task<Operator> Update(Operator op);
        Task Delete(int id);
    }
}
