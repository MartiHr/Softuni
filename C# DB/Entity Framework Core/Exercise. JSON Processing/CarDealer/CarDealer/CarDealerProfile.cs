using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierInputDto, Supplier>();

            CreateMap<PartInputDto, Part>();

            CreateMap<CarInputDto, Car>();

            CreateMap<CustomerInputDto, Customer>();

            CreateMap<SaleInputDto, Sale>();
        }
    }
}
