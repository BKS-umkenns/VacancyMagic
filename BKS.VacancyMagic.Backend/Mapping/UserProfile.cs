using AutoMapper;
using BKS.VacancyMagic.Backend.DAL.Models;
using BKS.VacancyMagic.Backend.Models.User;

namespace BKS.VacancyMagic.Backend.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDTO, User>()
            .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Login))
            .ForMember(dest => dest.PasswordHash, src => src.MapFrom(x => x.Password))
            .ReverseMap()
            .ForMember(dest => dest.Login, src => src.MapFrom(x => x.Name))
            .ForMember(dest => dest.Password, src => src.MapFrom(x => x.PasswordHash));
    }
}
