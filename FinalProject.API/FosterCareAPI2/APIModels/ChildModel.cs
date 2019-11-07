using System;
using System.Collections.Generic;
using FosterCareAPI2.Core.Models;

namespace FosterCareAPI2.ApiModels
{
    public class ChildModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Dob { get; set; }

        public string MoveInDate { get; set; }

        public IEnumerable<ChildHome> ChildHomes { get; set; }
    }
}
