using System.Linq;
using AutoMapper;
using ZawajApp.api.Dtos;
using ZawajApp.api.Models;

namespace ZawajApp.api.Helpers
{
    public class AutomMapperProfiles : Profile
    {
      public AutomMapperProfiles()
      {
          CreateMap<User,UserForListDto>()
           .ForMember(destinationMember=>destinationMember.PhotoURL,opt=>{opt.MapFrom(src=>src.Photos.FirstOrDefault(p=>p.IsMain).Url);})
           .ForMember(destinationMember=>destinationMember.Age,opt=>{opt.ResolveUsing(src=>src.DateOfBirth.CalculateAge());});
          CreateMap<User,UserForDetailsDto>()
          .ForMember(destinationMember=>destinationMember.PhotoURL,opt=>{opt.MapFrom(src=>src.Photos.FirstOrDefault(p=>p.IsMain).Url);})
          .ForMember(destinationMember=>destinationMember.Age,opt=>{opt.ResolveUsing(src=>src.DateOfBirth.CalculateAge());});
          CreateMap<Photo,PhotoForDetailsDto>();
          CreateMap<UserForUpdateDto,User>();
      }  
    }
}