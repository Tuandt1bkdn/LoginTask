using LoginTask.Models;
using AutoMapper;

namespace LoginTask.DBContext
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CreateRequest, UserClass>();
        }
    }
}
