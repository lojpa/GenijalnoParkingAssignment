using GenijalnoParkingAssignment.Models;
using GenijalnoParkingAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenijalnoParkingAssignment.Controllers
{
    [Route("api/parkingDetails")]
    [ApiController]
    public class ParkingDetailController : Controller
    {
        private readonly IParkingDetailService _parkingDetailService;

        public ParkingDetailController(IParkingDetailService parkingDetailService)
        {
            _parkingDetailService = parkingDetailService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingDetail>> GetParkingDetail(int id)
        {
            var parkingDetail = await _parkingDetailService.Get(id);
            if (parkingDetail == null)
                return NotFound();
            return Ok(parkingDetail);
        }

        [HttpGet]
        public async Task<ActionResult<ParkingDetail>> GetParkingDetails()
        {
            var parkingDetails = await _parkingDetailService.GetAll();

            return Ok(parkingDetails);
        }

        [HttpPost]
        public async Task<ActionResult<ParkingDetail>> CreateParkingDetail(ParkingDetail parkingDetail)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var createdparkingDetail = await _parkingDetailService.Create(parkingDetail);

            return Ok(createdparkingDetail);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteParkingDetail(int id)
        {
            await _parkingDetailService.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<ParkingDetail>> UpdateParkingDetail(ParkingDetail parkingDetail)
        {
            if (parkingDetail == null)
                return BadRequest();

            //var pd = await _parkingDetailService.Get(id);

            //if (pd == null)
            //    return BadRequest();

            var updatedParkingDetail = await _parkingDetailService.Update(parkingDetail);

            return Ok(updatedParkingDetail);
        }
    }
}
