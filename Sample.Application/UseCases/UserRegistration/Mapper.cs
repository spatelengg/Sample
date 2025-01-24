using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Sample.Domain.Entities;


namespace Sample.Application.UseCases.UserRegistration
{
    public sealed class  Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<UserRegistrationRequest, User>();
            CreateMap<User, UserRegistrationResponse>();
        }
    }
}
