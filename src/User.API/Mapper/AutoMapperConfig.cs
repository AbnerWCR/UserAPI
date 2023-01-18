using AutoMapper;
using User.API.ViewModels;
using User.Domain.DTOs;
using User.Domain.Entities;
using User.Services.DTOs;

namespace User.API.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapperConfigurationExpression AddMapping(
            this IMapperConfigurationExpression cfg)
        {           
            cfg.CreateMap<Domain.Entities.User, UserDTO>()
            .ForMember(x => x.FirstName, x => x.MapFrom(u => u.Name.FirstName))
            .ForMember(x => x.LastName, x => x.MapFrom(u => u.Name.LastName))
            .ForMember(x => x.Email, x => x.MapFrom(u => u.Email.Address))
            .ForMember(x => x.Password, x => x.MapFrom(u => u.Password.PasswordText))
            .ForMember(x => x.PasswordHash, x => x.MapFrom(u => u.Password.PasswordHash))
            .ForMember(x => x.Role, x => x.MapFrom(u => u.Role.UserRole))
            .ReverseMap();


            cfg.CreateMap<CreateUserViewModel, UserDTO>().ReverseMap();
            cfg.CreateMap<UpdateUserViewModel, UserDTO>().ReverseMap();
            cfg.CreateMap<UpdatePasswordViewModel, UserDTO>().ReverseMap();
            cfg.CreateMap<UpdateUserRoleViewModel, UserDTO>().ReverseMap();

            cfg.CreateMap<Error, ErrorDTO>()
            .ReverseMap();

            return cfg;
        }
    }
}
