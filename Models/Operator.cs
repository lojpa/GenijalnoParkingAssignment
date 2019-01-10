using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GenijalnoParkingAssignment.Models
{
    public class Operator
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; } 

        public List<ParkingDetail> ParkingDetails { get; set; }
    }
}