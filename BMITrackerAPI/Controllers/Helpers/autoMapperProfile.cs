using AutoMapper;
using BussinessObject;

using BussinessObject.MapData;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace BMITrackerAPI.Controllers.Helpers
{
    public class autoMapperProfile :Profile
    {
        public autoMapperProfile() 
        {
            CreateMap<favoriteFood,favoriteFoodInfo>().ReverseMap();
            CreateMap<user,loginData>().ReverseMap();
            CreateMap<user,signUpData>().ReverseMap();
            CreateMap<food,foodInfo>().ReverseMap();
            CreateMap<user,trainerInfo>().ReverseMap();
            CreateMap<Menu,MenuInfo>().ReverseMap();
            CreateMap<role,roleInfo>().ReverseMap();
            CreateMap<Schedule,ScheduleInfo>().ReverseMap();
            CreateMap<feedback,feedbackInfo>().ReverseMap();
            CreateMap<blog,blogInfo>().ReverseMap();
            CreateMap<message,messInfo>().ReverseMap();
            CreateMap<userBodyMax,userBodyMaxInfo>().ReverseMap();
            CreateMap<Service,serviceInfo>().ReverseMap();
            CreateMap<ServiceType, serviveTypeInfo>().ReverseMap();
            CreateMap<notification,notiInfo>().ReverseMap();
            CreateMap<trackForm,trackformInfo>().ReverseMap();
            CreateMap<Category, cateInfo>().ReverseMap();
            CreateMap<ingredient, ingriInfo>().ReverseMap();
            CreateMap<complement,ComplementInfo>().ReverseMap(); 
            CreateMap<userBodyMax,userBodyMaxServiceInfo>().ReverseMap();
        }
    }
}
