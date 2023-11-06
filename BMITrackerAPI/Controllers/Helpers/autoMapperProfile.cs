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
            CreateMap<payment,PaymentInfo>().ReverseMap();
            CreateMap<Order,orderInfo>().ReverseMap();
            CreateMap<orderDetail,orderDetailsDTO>().ReverseMap();
            CreateMap<Service,serviceInfo>().ReverseMap();
            CreateMap<ServiceType, serviveTypeInfo>().ReverseMap();
        }
    }
}
