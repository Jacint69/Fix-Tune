using AutoMapper;
using Fix_Tune.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Tune.Logic
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {

            CreateMap<Car, CarDTO>();
            CreateMap<Issue, IssueDTO>();
        }
    }
}
