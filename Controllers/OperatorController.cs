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
    [Route("api/operators")]
    [ApiController]
    public class OperatorController : Controller
    {
        private readonly IOperatorService _operatorService;

        public OperatorController(IOperatorService operatorService)
        {
            _operatorService = operatorService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Operator>> GetOperator(int id)
        {
            var op = await _operatorService.Get(id);
            if (op == null)
                return NotFound();
            return Ok(op);
        }

        [HttpGet]
        public async Task<ActionResult<Operator>> GetOperators()
        {
            var ops = await _operatorService.GetAll();

            return Ok(ops);
        }

        [HttpPost]
        public async Task<ActionResult<Operator>> CreateOperator(Operator op)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var createdOperator = await _operatorService.Create(op);
            return Ok(createdOperator);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOperator(int id)
        {
            await _operatorService.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Operator>> UpdateOperator(Operator op)
        {
            var updatedOperator = await _operatorService.Update(op);
            return Ok(updatedOperator);
        }


    }
}
