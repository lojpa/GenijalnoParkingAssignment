using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenijalnoParkingAssignment.Models
{
    public class Parking
    {

        public int Id { get; set; }

        [Required]
        public int TotalNumberOfSlots { get; set; }

        public int NumberOfFreeSlots { get; set; }

        public List<ParkingDetail> ParkingDetails { get; set; }

    }
}
