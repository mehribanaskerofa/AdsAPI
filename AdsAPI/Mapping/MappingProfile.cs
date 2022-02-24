using AdsAPI.DataAccess.Entity;
using AdsAPI.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdsAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Advertisement, AdvertisementDTO>().ReverseMap();
        }
    }
}
