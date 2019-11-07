using System;
using System.Collections.Generic;
using System.Text;

namespace FosterCareAPI2.Core.Models
{
    public class ChildHome
    {

        public int ChildId { get; set; }

        public Child Child { get; set; }

        public int HouseId { get; set; }

        public House House { get; set; }

    }
}
