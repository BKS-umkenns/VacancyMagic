using AutoMapper;
using BKS.VacancyMagic.Backend.DAL.Models;
using BKS.VacancyMagic.Backend.Models.Search;
using BKS.VacancyMagic.Backend.Models.Services;
using BKS.VacancyMagic.Backend.Models.User;
using BKS.VacancyMagic.Backend.Models.Vacancy;
using BKS.VacancyMagic.Backend.Services;

namespace BKS.VacancyMagic.Backend.Mapping;

public class VacancyProfie : Profile
{
    public VacancyProfie()
    {
        CreateMap<SuperJobVacancyPrompt, SearchResultDTO>()
            .ForMember(dest => dest.keyword, src => src.MapFrom(x => x.Keyword))
            .ForMember(dest => dest.experience, src => src.MapFrom(x => x.Experience))
            .ForMember(dest => dest.gender, src => src.MapFrom(x => x.Gender))
            .ForMember(dest => dest.payment_from, src => src.MapFrom(x => x.PaymentFrom))
            .ForMember(dest => dest.payment_to, src => src.MapFrom(x => x.PaymentTo))
            .ForMember(dest => dest.period, src => src.MapFrom(x => x.Period))
            .ForMember(dest => dest.town, src => src.MapFrom(x => x.Town))
            .ReverseMap()
            .ForMember(dest => dest.Keyword, src => src.MapFrom(x => x.keyword))
            .ForMember(dest => dest.Experience, src => src.MapFrom(x => x.experience))
            .ForMember(dest => dest.Gender, src => src.MapFrom(x => x.gender))
            .ForMember(dest => dest.PaymentFrom, src => src.MapFrom(x => x.payment_from))
            .ForMember(dest => dest.PaymentTo, src => src.MapFrom(x => x.payment_to))
            .ForMember(dest => dest.Period, src => src.MapFrom(x => x.period))
            .ForMember(dest => dest.Town, src => src.MapFrom(x => x.town));

        CreateMap<VacancyRecordObject, SearchValue>()
            .ForMember(dest => dest.VacancyId, src => src.MapFrom(x => x.id))
            .ForMember(dest => dest.ServiceId, o => o.Ignore())
            .ForMember(dest => dest.Id, o => o.Ignore())
            .ForMember(dest => dest.ReplyId, o => o.Ignore())
            .ForMember(dest => dest.UserId, o => o.Ignore())
            .ReverseMap()
            .ForMember(dest => dest.id, src => src.MapFrom(x => x.VacancyId));

        CreateMap<ServiceUserInfoDTO, UserInfoSuperjob>()
            .ForMember(dest => dest.email, src => src.MapFrom(x => x.Email))
            .ForMember(dest => dest.id_cv, src => src.MapFrom(x => x.ResumeId))
            .ForMember(dest => dest.id, o => o.Ignore())
            .ForMember(dest => dest.name, o => o.Ignore())
            .ReverseMap()
            .ForMember(dest => dest.Email, src => src.MapFrom(x => x.email))
            .ForMember(dest => dest.ResumeId, src => src.MapFrom(x => x.id_cv));

        CreateMap<UserCVDTO, ResumeObjectSuperjob>()
            .ForMember(dest => dest.id, src => src.MapFrom(x => x.id_cv))
            .ReverseMap()
            .ForMember(dest => dest.id_cv, src => src.MapFrom(x => x.id));
    }
}
