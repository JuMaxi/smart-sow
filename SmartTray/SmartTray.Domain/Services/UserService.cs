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

        // TODO: Before adding the user, needs to calculate hash function and generate salt
        // Method to insert a new user
        public async Task Insert(User user)
        {
            // TODO: Before adding the user, needs to calculate hash function and generate salt
            await _userRepository.Insert(user);
        }

        // Method to fetch a user by id from the database
        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        // Method to update a user account into the data base
        // To update the password, users will have another "button" to it and a different method.
        public async Task Update(User user)
        {
            User toUpdate = await _userRepository.GetById(user.Id);

            toUpdate.Name = user.Name;
            toUpdate.Email = user.Email;
            toUpdate.Postcode = user.Postcode;

            await _userRepository.Update(toUpdate);
        }

        // TODO: Insert the updatePassword method. It must have a salt and a hash function.

        // TODO: Insert the delete method
        // TODO: While deleting an user account, it must delete user's trays, tray's sensor readings, tray's growth settings
    }
}
