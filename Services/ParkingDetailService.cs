using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenijalnoParkingAssignment.Models;
using GenijalnoParkingAssignment.Repositories;

namespace GenijalnoParkingAssignment.Services
{
    public class ParkingDetailService : IParkingDetailService
    {
        private readonly IParkingDetailRepository _parkingDetailRepository;

        public ParkingDetailService(IParkingDetailRepository parkingDetailRepository)
        {
            _parkingDetailRepository = parkingDetailRepository;
        }

        public async  Task<ParkingDetail> Create(ParkingDetail parkingDetail)
        {
            var createdParkingDetail = await _parkingDetailRepository.Create(parkingDetail);
            return createdParkingDetail;
        }

        public async Task Delete(int id)
        {
            await _parkingDetailRepository.Delete(id);
        }

        public async Task<ParkingDetail> Get(int id)
        {
            var parkingDetail = await _parkingDetailRepository.Get(id);
            return parkingDetail;
        }

        public async Task<IEnumerable<ParkingDetail>> GetAll()
        {
            var parkingDetails = await _parkingDetailRepository.GetAll();
            return parkingDetails;
        }

        public async Task<ParkingDetail> Update(ParkingDetail parkingDetail)
        {
            var updatedParkingDetail = await _parkingDetailRepository.Update(parkingDetail);
            return updatedParkingDetail;
        }
    }
}
