using AutoMapper;
using MicroService.UI.Obilet.MVC.Models.BusModels;
using MicroServices.Services.Obilet.Application.Dtos.Bus;
using MikroServices.UI.Obilet.MVC.Models.BusModels;

namespace MikroServices.UI.Obilet.MVC.Mapping
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<JourneyDto,JourneyViewModel>().ReverseMap();
            CreateMap<BusJourneyDto, BusJourneyViewModel>().ReverseMap();
            //CreateMap<Domain.OrderAggregate.Order, OrderDto>().ReverseMap();
            //CreateMap<Domain.OrderAggregate.OrderItem, OrderItemDto>().ReverseMap();
            //CreateMap<Address, AddressDto>().ReverseMap();

        }
    }
}
