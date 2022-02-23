using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor.Entities;

namespace Rookie.Ecom.Business
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            FromDataAccessorLayer();
            FromPresentationLayer();
        }

        private void FromPresentationLayer()
        {
            CreateMap<AddressDto, Address>();

            CreateMap<CategoryDto, Category>()
               .ForMember(d => d.Products, t => t.Ignore());

            CreateMap<CityDto, City>();

            CreateMap<OrderDto, Order>();

            CreateMap<OrderItemDto, OrderItem>();

            CreateMap<ProductDto, Product>();

            CreateMap<ProductImageDto, ProductImage>();

            CreateMap<RatingDto, Rating>();

            CreateMap<RoleDto, Role>();

            CreateMap<UserDto, User>();

            CreateMap<UserAccountDto, UserAccount>();
        }

        private void FromDataAccessorLayer()
        {
            CreateMap<Address, AddressDto>();

            CreateMap<Category, CategoryDto>();

            CreateMap<City, CityDto>();

            CreateMap<Order, OrderDto>();

            CreateMap<OrderItem, OrderItemDto>();

            CreateMap<Product, ProductDto>();

            CreateMap<ProductImage, ProductImageDto>();

            CreateMap<Rating, RatingDto>();

            CreateMap<Role, RoleDto>();

            CreateMap<User, UserDto>();

            CreateMap<UserAccount, UserAccountDto>();
        }
    }
}
