namespace st10384480AgriConnect.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }

        // New field to store the owner's email (farmer or employee)
        public string OwnerEmail { get; set; }
        public string Role { get; set; } // Optional: to distinguish Farmer or Employee
    }
}