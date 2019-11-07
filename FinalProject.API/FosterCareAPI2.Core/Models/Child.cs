using System;
using System.Collections.Generic;

namespace FosterCareAPI2.Core.Models
{
    public class Child
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Dob { get; set; }

        public string MoveInDate { get; set; }


        //public int AppointmentId { get; set; }
        //public Appointment Appointment { get; set; }

        public ICollection<ChildHome> ChildHomes { get; set; }

        //public ICollection<Appointment> Appts { get; set; }
    }
}