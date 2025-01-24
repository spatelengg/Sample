using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Sample.Domain.Entities;


namespace Sample.Application.UseCases.UserCreation
{
    public sealed class  Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<UserCreationRequest, User>();
            CreateMap<User, UserCreationResponse>();
        }
    }
}
