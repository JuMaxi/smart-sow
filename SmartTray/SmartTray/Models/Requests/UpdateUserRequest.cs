namespace SmartTray.API.Models.Requests
{
    public class UpdateUserRequest
    {
        // User is allowed to use the name they want, no need for surname
        public string Name { get; set; }

        // Email will be used as login to the user account
        public string Email { get; set; }

        // Asking the user postcode to fetch public API to sunrise and sunset to display it in the front-end (display-data.html)
        public string Postcode { get; set; }
    }
}

