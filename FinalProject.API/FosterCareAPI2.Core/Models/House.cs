using System.Collections.Generic;

namespace FosterCareAPI2.Core.Models
{
    public class House
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public ICollection<Child> Children { get; set; } = new List<Child>();
    }
}