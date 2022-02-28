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
            CreateMap<AddressInfoDto, Address>();


            //Cart
            CreateMap<CartDto, Cart>();
            CreateMap<CartInfoDto, Cart>()
                .ForMember(d => d.Product, t => t.Ignore())
                .ForMember(d => d.User, t => t.Ignore());


            //Category
            CreateMap<CategoryDto, Category>()
               .ForMember(d => d.Products, t => t.Ignore());


            //City
            CreateMap<CityDto, City>();


            //Order
            CreateMap<OrderDto, Order>();
            CreateMap<OrderInfoDto, Order>()
                .ForMember(d => d.orderItems, t => t.Ignore())
                .ForMember(d => d.User, t => t.Ignore());

            //OrderItem
            CreateMap<OrderItemDto, OrderItem>();
            CreateMap<OrderItemInfoDto, OrderItem>()
                .ForMember(d => d.Order, t => t.Ignore())
                .ForMember(d => d.Product, t => t.Ignore());


            //Product
            CreateMap<ProductDto, Product>();
            CreateMap<ProductInfoDto, Product>()
                .ForMember(d => d.Category, t => t.Ignore())
                .ForMember(d => d.ProductImages, t => t.Ignore());


            //ProductImage
            CreateMap<ProductImageDto, ProductImage>();
            CreateMap<ProductImageInfoDto, ProductImage>()
                .ForMember(d => d.Product, t => t.Ignore());


            //Rating
            CreateMap<RatingDto, Rating>();
            CreateMap<RatingInfoDto, Rating>()
                .ForMember(d => d.User, t => t.Ignore())
                .ForMember(d => d.Product, t => t.Ignore());


            //Role
            CreateMap<RoleDto, Role>();
            CreateMap<RoleInfoDto, Role>()
                .ForMember(d => d.User, t => t.Ignore());


            //User
            CreateMap<UserDto, User>();
            CreateMap<UserInfoDto, User>()
                .ForMember(d => d.Roles, t => t.Ignore())
                .ForMember(d => d.Orders, t => t.Ignore())
                .ForMember(d => d.UserAccount, t => t.Ignore());


            //UserAccount
            CreateMap<UserAccountDto, UserAccount>()
                 .ForMember(d => d.User, t => t.Ignore());
            CreateMap<UserAccountInfoDto, UserAccount>()
                 .ForMember(d => d.User, t => t.Ignore());
        }

        private void FromDataAccessorLayer()
        {
            //Address
            CreateMap<Address, AddressInfoDto>();
            CreateMap<Address, AddressDto>();


            //Cart
            CreateMap<Cart, CartDto>();
            CreateMap<Cart, CartInfoDto>();


            //Category
            CreateMap<Category, CategoryDto>();


            //City
            CreateMap<City, CityDto>();


            //Order
            CreateMap<Order, OrderDto>();
            CreateMap<Order, OrderInfoDto>();


            //OrderItem
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderItem, OrderItemInfoDto>();


            //Product
            CreateMap<Product, ProductDto>();
            CreateMap<Product, ProductInfoDto>();


            //ProductImage
            CreateMap<ProductImage, ProductImageDto>();
            CreateMap<ProductImage, ProductImageInfoDto>();

            //Rating
            CreateMap<Rating, RatingDto>();
            CreateMap<Rating, RatingInfoDto>();


            //Role
            CreateMap<Role, RoleDto>();
            CreateMap<Role, RoleInfoDto>();


            //User
            CreateMap<User, UserDto>();
            CreateMap<User, UserInfoDto>();
            

            //UserAccount
            CreateMap<UserAccount, UserAccountDto>();
            CreateMap<UserAccount, UserAccountInfoDto>();
        }
    }
}
