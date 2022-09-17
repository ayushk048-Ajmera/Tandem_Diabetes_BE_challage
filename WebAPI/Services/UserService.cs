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
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserResponseDTO> CreateUser(UserDTO user)
        {
            User userEntity = _mapper.Map<User>(user);
            User createdUser = await _userRepository.CreateUser(userEntity);

            _logger.LogInformation($"User has created with id : {createdUser.Id}");
            return _mapper.Map<UserResponseDTO>(createdUser);
        }

        public async Task<IEnumerable<UserResponseDTO>> GetAllUsers()
        {
            IEnumerable<User> users = await _userRepository.GetAllUsers();
            _logger.LogInformation($"{users.Count()} users are found");
            return _mapper.Map<IEnumerable<UserResponseDTO>>(users);
        }

        public async Task<UserResponseDTO> GetUserByEmail(string email)
        {
            User? users = await _userRepository.GetUserByEmail(email);
            _logger.LogInformation($"User has found with email : {email}");
            return _mapper.Map<UserResponseDTO>(users);
        }
    }
}
