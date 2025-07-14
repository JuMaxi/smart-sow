using System.Security.Cryptography;
using System.Text;

namespace SmartTray.Domain.Services
{
    public class HashingHelper
    {
        // This short function calculates a randon salt to be stored into the database
        public static string GetRandomSalt() => Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5);

        // This short function calculates a randon token to the tray
        public static string GetRandonToken() => Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);

        // This function calculates a hash to the user password. This and the salt will be stored into the database, not the password.
        public static string CalculateHash(string password)
        {
            var data = Encoding.UTF8.GetBytes(password);
            byte[] hashedData = SHA512.HashData(data);
            return Convert.ToBase64String(hashedData);
        }
    }
}
