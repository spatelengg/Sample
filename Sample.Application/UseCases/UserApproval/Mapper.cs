using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Sample.Domain.Entities;

namespace Sample.Application.UseCases.UserApproval
{
    public sealed class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<UserApprovalRequest, User>();
            CreateMap<User, UserApprovalResponse>();
        }
    }
}
