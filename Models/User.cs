﻿namespace st10384480AgriConnect.Models
{
    public class User
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // "Farmer" or "Employee"
    }
}