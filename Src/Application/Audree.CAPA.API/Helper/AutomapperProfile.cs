using Audree.CAPA.Application.DTO_s.Masters;
using Audree.CAPA.Core.Models.Masters;
using AutoMapper;

namespace Audree.CAPA.API.Helper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();   
        }
    }
}
