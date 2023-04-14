using AutoMapper;
using Cms.Web.Models;
using Cms.Web.ViewModel;

namespace Cms.Web.Mapping
{
    public class ViewModelMapping:Profile
    {
        public ViewModelMapping()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Doctor, DoctorViewModel>().ReverseMap();
            CreateMap<Blog, BlogViewModel>().ReverseMap();
            CreateMap<HomePage, HomePageViewModel>().ReverseMap();
            CreateMap<Referans, ReferansViewModel>().ReverseMap();
        }
    }
}
