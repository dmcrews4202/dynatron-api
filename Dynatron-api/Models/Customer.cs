namespace Dynatron.Models
{
    public class Customer 
    {
        public int Id {get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}