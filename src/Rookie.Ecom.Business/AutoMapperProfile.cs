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

            //Address
            CreateMap<AddressDto, Address>();
            CreateMap<AddressCreateDto, Address>();
            CreateMap<AddressUpdateDto, Address>();


            //Category
            CreateMap<CategoryDto, Category>()
               .ForMember(d => d.Products, t => t.Ignore());


            //City
            CreateMap<CityDto, City>();


            //Order
            CreateMap<OrderDto, Order>();


            //OrderItem
            CreateMap<OrderItemDto, OrderItem>();


            //Product
            CreateMap<ProductDto, Product>();


            //ProductImage
            CreateMap<ProductImageDto, ProductImage>();


            //Rating
            CreateMap<RatingDto, Rating>();


            //Role
            CreateMap<RoleDto, Role>();


            //User
            CreateMap<UserDto, User>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();


            //UserAccount
            CreateMap<UserAccountDto, UserAccount>();
        }

        private void FromDataAccessorLayer()
        {
            //Address
            CreateMap<Address, AddressCreateDto>();
            CreateMap<Address, AddressUpdateDto>();
            CreateMap<Address, AddressDto>();


            //Category
            CreateMap<Category, CategoryDto>();


            //City
            CreateMap<City, CityDto>();


            //Order
            CreateMap<Order, OrderDto>();


            //OrderItem
            CreateMap<OrderItem, OrderItemDto>();


            //Product
            CreateMap<Product, ProductDto>();


            //ProductImage
            CreateMap<ProductImage, ProductImageDto>();


            //Rating
            CreateMap<Rating, RatingDto>();


            //Role
            CreateMap<Role, RoleDto>();


            //User
            CreateMap<User, UserDto>();
            CreateMap<User, UserCreateDto>();
            CreateMap<User, UserUpdateDto>();
            

            //UserAccount
            CreateMap<UserAccount, UserAccountDto>();
        }
    }
}
