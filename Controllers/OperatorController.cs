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
    [Route("api/operators")]
    [ApiController]
    public class OperatorController : Controller
    {
        private readonly IOperatorRepository _operatorRepository;

        public OperatorController(IOperatorRepository operatorRepository)
        {
            _operatorRepository = operatorRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Operator>> GetOperator(int id)
        {
            var op = await _operatorRepository.Get(id);
            if (op == null)
                return NotFound();
            return Ok(new { op });
        }

        [HttpGet]
        public async Task<ActionResult<Operator>> GetOperators()
        {
            var ops = await _operatorRepository.GetAll();

            return Ok(new { ops });
        }

        [HttpPost]
        public async Task<ActionResult<Operator>> CreateOperator(Operator op)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var createdOperator = await _operatorRepository.Create(op);
            return Ok(createdOperator);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOperator(int id)
        {
            await _operatorRepository.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOperator(Operator op)
        {
            var updatedOperator = await _operatorRepository.Update(op);
            return Ok(updatedOperator);
        }


    }
}
