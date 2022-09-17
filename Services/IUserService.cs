using Tandem_Diabetes_BE_challenge.DTOs;

namespace Tandem_Diabetes_BE_challenge.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<UserResponseDTO>> getAllUsers();

        public Task<IEnumerable<UserResponseDTO>> getUserByEmail(string email);

        public Task<UserResponseDTO> createUser(UserDTO user);
    }
}
