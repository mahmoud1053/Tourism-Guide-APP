namespace WebApplication2.Entities
{
    public class Programs
    {
        public int Program_Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Night { get; set; }
        public int Day { get; set; }
        public int Rating { get; set; }

        public ICollection<Program_Places>? ProgramPlaces { get; set; }

    }
}
