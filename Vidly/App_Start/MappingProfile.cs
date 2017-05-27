﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Models;
using Vidly.Dtos;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>()
               .ForMember(m=>m.Id, opt=>opt.Ignore());

            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Movie, MovieDto>()
                .ForMember(m=>m.id, opt=>opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>();
        }
    }
}