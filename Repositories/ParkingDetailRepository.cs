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
    public class ParkingDetailRepository : IParkingDetailRepository
    {

        private readonly GenijalnoParkingContext _genijalnoParkingContext;

        public ParkingDetailRepository(GenijalnoParkingContext genijalnoParkingContext)
        {
            _genijalnoParkingContext = genijalnoParkingContext;
        }

        public async Task<ParkingDetail> Create(ParkingDetail parkingDetail)
        {
            if (parkingDetail == null)
                return null;

            _genijalnoParkingContext.ParkingDetails.Add(parkingDetail);

            await _genijalnoParkingContext.SaveChangesAsync();
            return parkingDetail;
        }

        public async Task Delete(int id)
        {
            var parkingDetail = await _genijalnoParkingContext.ParkingDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (parkingDetail != null)
            {
                _genijalnoParkingContext.ParkingDetails.Remove(parkingDetail);
                await _genijalnoParkingContext.SaveChangesAsync();
            }
        }

        public async Task<ParkingDetail> Get(int id)
        {
            var parkingDetail = await _genijalnoParkingContext.ParkingDetails.Include(pdc => pdc.Customer).Include(pdo => pdo.Operator).Include(pdp => pdp.Parking).FirstOrDefaultAsync(x => x.Id == id);

            if (parkingDetail == null)
                return null;

            return parkingDetail;
        }

        public async Task<IEnumerable<ParkingDetail>> GetAll()
        {
            var parkingDetails = await _genijalnoParkingContext.ParkingDetails.Include(pdc => pdc.Customer).Include(pdo => pdo.Operator).Include(pdp => pdp.Parking).ToListAsync();

            return parkingDetails;
        }

        public async Task<ParkingDetail> Update(ParkingDetail parkingDetail)
        {
            if (parkingDetail == null)
                return null;

            _genijalnoParkingContext.ParkingDetails.Update(parkingDetail);


            await _genijalnoParkingContext.SaveChangesAsync();

            return parkingDetail;
        }
    }
}
