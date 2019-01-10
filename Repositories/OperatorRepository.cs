using GenijalnoParkingAssignment.Context;
using GenijalnoParkingAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenijalnoParkingAssignment.Repositories
{
    public class OperatorRepository : IOperatorRepository
    {
        private readonly GenijalnoParkingContext _genijalnoParkingContext;

        public OperatorRepository(GenijalnoParkingContext genijalnoParkingContext)
        {
            _genijalnoParkingContext = genijalnoParkingContext;
        }

        public async Task<Operator> Create(Operator op)
        {
            if (op == null)
                return null;

            _genijalnoParkingContext.Operators.Add(op);

            await _genijalnoParkingContext.SaveChangesAsync();
            return op;
        }

        public async Task Delete(int id)
        {
            var op = await _genijalnoParkingContext.Operators.FirstOrDefaultAsync(x => x.Id == id);
            if (op != null)
            {
                _genijalnoParkingContext.Operators.Remove(op);
                await _genijalnoParkingContext.SaveChangesAsync();
            }

        }

        public async Task<Operator> Get(int id)
        {
            var op = await _genijalnoParkingContext.Operators.Include(pd => pd.ParkingDetails).FirstOrDefaultAsync(x => x.Id == id);

            if (op == null)
                return null;

            return op;
        }

        public async Task<IEnumerable<Operator>> GetAll()
        {
            var ops = await _genijalnoParkingContext.Operators.Include(pd => pd.ParkingDetails).ToListAsync();

            return ops;
        }

        public async Task<Operator> Update(Operator op)
        {
            if (op == null)
                return null;

            _genijalnoParkingContext.Operators.Update(op);

            await _genijalnoParkingContext.SaveChangesAsync();
            return op;
        }
    }
}
