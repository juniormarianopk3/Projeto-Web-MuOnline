using AutoMapper;
using MuOnlineWebMVC.Models;
using MuOnlineWebMVC.Models.AccountViewModels;
using MuOnlineWebMVC.Models.ViewModels.PainelViewModels;


namespace MuOnlineWebMVC.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<ToChangePasswordViewModel, MembInfo>().ReverseMap();
            CreateMap<CharactersViewModels, Character>().ReverseMap();
            CreateMap<RegisterMembInfoViewModel, MembInfo>().ReverseMap();
        }
    }
}
