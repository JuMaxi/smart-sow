namespace SmartTray.Domain.Models
{
    public class User
    {
        public int Id { get; set; }

        // User is allowed to use the name they want, no need for surname
        public string Name { get; set; }

        // Email will be used as login to the user account
        public string Email { get; set; }

        // The password will not be stored into the database, I will use a salt + hash function to store it 
        public string PasswordHash { get; set; } 

        // This is the salt generated to the password hash
        public string Salt { get; set; }

        // Asking the user postcode to fetch public API to sunrise and sunset to display it in the front-end (display-data.html)
        public string Postcode { get; set; } 
    }
}
