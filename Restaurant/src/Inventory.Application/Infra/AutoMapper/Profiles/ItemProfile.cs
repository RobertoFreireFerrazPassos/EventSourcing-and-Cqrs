using AutoMapper;
using Inventory.Application.DataContracts.Data;
using Inventory.Domain.Entities;

namespace Inventory.Application.Infra.AutoMapper.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemEntity>().ReverseMap();
        }
    }
}
