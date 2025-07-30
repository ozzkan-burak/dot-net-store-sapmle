using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace StoreApp.Infrastructre.Mapper
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<ProductDtoForInsertion, Product>();
    }
  }
}