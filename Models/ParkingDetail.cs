using System;

namespace GenijalnoParkingAssignment.Models
{
    public class ParkingDetail
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int OperatorId { get; set; }
        public Operator Operator { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime? ExitDate { get; set; }

        public decimal Cost { get; set; }

        public int ParkingId { get; set; }
        public Parking Parking { get; set; }
    }
}