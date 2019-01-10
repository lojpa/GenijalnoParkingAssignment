using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenijalnoParkingAssignment.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public VehicleType VehicleType { get; set; }

        public string LicencePlateNumber { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
