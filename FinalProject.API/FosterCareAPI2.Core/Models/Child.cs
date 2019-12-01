namespace FosterCareAPI2.Core.Models
{
    public class Child
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Dob { get; set; }

        public string MoveInDate { get; set; }


        public int HouseId { get; set; }
        public House House { get; set; }
    }
}