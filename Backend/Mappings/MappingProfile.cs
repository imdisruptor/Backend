using AutoMapper;
using Backend.Models.Entities;
using Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Mappings
{
    public class ViewModelToEntityProfile : Profile
    {
        public ViewModelToEntityProfile()
        {
            CreateMap<RegisterViewModel, ApplicationUser>()
                .ForMember(au => au.UserName, map => map.MapFrom(rvm => rvm.Email));
        }
    }
}
