using AutoMapper;
using Tandem_Diabetes_BE_challenge.DTOs;
using Tandem_Diabetes_BE_challenge.Entities;

namespace Tandem_Diabetes_BE_challenge.Mapper
{
    public class EntityToModelMapper : Profile
    {
        public EntityToModelMapper()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserResponseDTO>()
                .ForMember(userResponseDTO => userResponseDTO.FullName, opt => opt.MapFrom(userEntity => $"{userEntity.FirstName} {userEntity.MiddleName} {userEntity.LastName}") )
                .ForMember(userResponseDTO => userResponseDTO.userId, opt => opt.MapFrom(userEntity => userEntity.Id));
        }
    }
}
