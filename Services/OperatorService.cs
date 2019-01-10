using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenijalnoParkingAssignment.Models;
using GenijalnoParkingAssignment.Repositories;

namespace GenijalnoParkingAssignment.Services
{
    public class OperatorService : IOperatorService
    {
        private readonly IOperatorRepository _operatorRepository;

        public OperatorService(IOperatorRepository operatorRepository)
        {
            _operatorRepository = operatorRepository;
        }

        public async Task<Operator> Create(Operator op)
        {
            var createdOperator = await _operatorRepository.Create(op);
            return createdOperator;
        }

        public async Task Delete(int id)
        {
            await _operatorRepository.Delete(id);
        }

        public async Task<Operator> Get(int id)
        {
            var op = await _operatorRepository.Get(id);
            return op;
        }

        public async Task<IEnumerable<Operator>> GetAll()
        {
            var ops = await _operatorRepository.GetAll();
            return ops;
        }

        public async Task<Operator> Update(Operator op)
        {
            var updatedOperator = await _operatorRepository.Update(op);
            return updatedOperator;
        }
    }
}
