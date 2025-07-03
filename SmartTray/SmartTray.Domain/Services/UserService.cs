using SmartTray.Domain.DTO;
using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;

namespace SmartTray.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        // Constructor for working with database calling the userRepository interface
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Method to insert a new user
        public async Task Insert(UserDTO userDTO)
        {
            // Calling this function that generates a randon Salt to be stored into the database for aditional safety
            string salt = HashingHelper.GetRandomSalt();

            // Calling this function that generates a hash with base in the user password. It will be stored into the database with the salt.
            // Password is not stored into the data base
            string hash = HashingHelper.CalculateHash(userDTO.Password + salt);

            // Convert UserDTO to User
            User user = new()
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                PasswordHash = hash,
                Salt = salt,
                Postcode = userDTO.Postcode
            };

            await _userRepository.Insert(user);
        }

        // Method to fetch a user by id from the database
        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        // Method to update a user account into the data base
        // To update the password, users will have another "button" to it and a different method.
        public async Task Update(UserDTO userDTO)
        {
            User toUpdate = await _userRepository.GetById(userDTO.Id);

            toUpdate.Name = userDTO.Name;
            toUpdate.Email = userDTO.Email;
            toUpdate.Postcode = userDTO.Postcode;

            await _userRepository.Update(toUpdate);
        }

        public async Task<LoginResult> Login(string email, string password)
        {
            const string errorMessage = "Invalid username/password combination. Please try again.";

            // Fetch user from database by email, if it is null, there is no user with this email registered
            User user = await _userRepository.GetByEmail(email);

            if (user is not null)
            {
                string hash = HashingHelper.CalculateHash(password + user.Salt);

                if(user.PasswordHash == hash)
                {
                    return new LoginResult(user);
                }
            }

            return new LoginResult(errorMessage);
        }

        // TODO: Insert the updatePassword method. It must have a salt and a hash function.

        // TODO: Insert the delete method
        // TODO: While deleting an user account, it must delete user's trays, tray's sensor readings, tray's growth settings
    }
}
