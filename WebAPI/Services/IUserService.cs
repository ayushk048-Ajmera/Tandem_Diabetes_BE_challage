using Tandem_Diabetes_BE_challenge.DTOs;

namespace Tandem_Diabetes_BE_challenge.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<UserResponseDTO>> GetAllUsers();

        public Task<UserResponseDTO> GetUserByEmail(string email);

        public Task<UserResponseDTO> CreateUser(UserDTO user);
    }
}
