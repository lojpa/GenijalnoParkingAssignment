using GenijalnoParkingAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenijalnoParkingAssignment.Repositories
{
    public interface IParkingDetailRepository
    {
        Task<ParkingDetail> Get(int id);
        Task<IEnumerable<ParkingDetail>> GetAll();
        Task<ParkingDetail> Create(ParkingDetail parkingDetail);
        Task<ParkingDetail> Update(ParkingDetail parkingDetail);
        Task Delete(int id);
    }
}
