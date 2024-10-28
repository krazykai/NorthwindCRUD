using AutoMapper;
using Northwind.Models;
using NorthwindCRUD.Models.Parameters;

namespace NorthwindCRUD.Models
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<CustomerCreateParameters, Customer>();
            CreateMap<CustomerUpdateParameters, Customer>();
        }
    }
}
