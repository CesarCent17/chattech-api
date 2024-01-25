using AutoMapper;
using Azure;
using chattech_users.Models;
using chattech_users.Models.Dto;
using chattech_users.Models.Entities;

namespace chattech_users.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
        }    
    }
}
