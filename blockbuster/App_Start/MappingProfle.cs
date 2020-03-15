using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using blockbuster.Models;
using blockbuster.Dto;

namespace blockbuster.App_Start
{
    public class MappingProfle : Profile
    {
        public MappingProfle()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            Mapper.CreateMap<Movie, RentedMoviesDto>();
            Mapper.CreateMap<RentedMoviesDto, Movie>();

        }
    }
}