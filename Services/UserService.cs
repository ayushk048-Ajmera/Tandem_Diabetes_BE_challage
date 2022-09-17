using AutoMapper;
using Tandem_Diabetes_BE_challenge.DTOs;
using Tandem_Diabetes_BE_challenge.Entities;
using Tandem_Diabetes_BE_challenge.Repository;

namespace Tandem_Diabetes_BE_challenge.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponseDTO> createUser(UserDTO user)
        {
            User userEntity = _mapper.Map<User>(user);
            User createdUser = await _userRepository.createUser(userEntity);
            return _mapper.Map<UserResponseDTO>(createdUser);
        }

        public async Task<IEnumerable<UserResponseDTO>> getAllUsers()
        {
            IEnumerable<User> users = await _userRepository.getAllUsers();
            return _mapper.Map<IEnumerable<UserResponseDTO>>(users);
        }

        public async Task<IEnumerable<UserResponseDTO>> getUserByEmail(string email)
        {
            IEnumerable<User> users = await _userRepository.getUserByEmail(email);
            return _mapper.Map<IEnumerable<UserResponseDTO>>(users);
        }
    }
}
