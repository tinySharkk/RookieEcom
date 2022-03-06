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
            CreateMap<AddAddressDto, Address>()
                .ForMember(d => d.User, t => t.Ignore());
            CreateMap<UpdateAddressDto, Address>()
                .ForMember(d => d.Id, t => t.Ignore())
                .ForMember(d => d.UpdatedDate, t => t.Ignore())
                .ForMember(d => d.CreatedDate, t => t.Ignore())
                .ForMember(d => d.CreatorId, t => t.Ignore())
                .ForMember(d => d.User, t => t.Ignore())
                .ForMember(d => d.UserId, t => t.Ignore());

            //Cart
            CreateMap<CartDto, Cart>();
            CreateMap<CartInfoDto, Cart>()
                .ForMember(d => d.Product, t => t.Ignore())
                .ForMember(d => d.User, t => t.Ignore());
            CreateMap<UpdateCartDto, Cart>()
                .ForMember(d => d.Id, t => t.Ignore())
                .ForMember(d => d.UpdatedDate, t => t.Ignore())
                .ForMember(d => d.CreatedDate, t => t.Ignore())
                .ForMember(d => d.CreatorId, t => t.Ignore())
                .ForMember(d => d.Product, t => t.Ignore())
                .ForMember(d => d.User, t => t.Ignore())
                .ForMember(d => d.UserId, t => t.Ignore())
                .ForMember(d => d.ProductId, t => t.Ignore());


            //Category
            CreateMap<CategoryDto, Category>()
               .ForMember(d => d.Products, t => t.Ignore());
            CreateMap<UpdateCategoryDto, Category>()
                .ForMember(d => d.Id, t => t.Ignore())
                .ForMember(d => d.UpdatedDate, t => t.Ignore())
                .ForMember(d => d.CreatedDate, t => t.Ignore())
                .ForMember(d => d.CreatorId, t => t.Ignore());


            //City
            CreateMap<CityDto, City>();
            CreateMap<UpdateCityDto, City>()
                .ForMember(d => d.Id, t => t.Ignore())
                .ForMember(d => d.UpdatedDate, t => t.Ignore())
                .ForMember(d => d.CreatedDate, t => t.Ignore())
                .ForMember(d => d.CreatorId, t => t.Ignore());


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
            CreateMap<UpdateProductDto, Product>()
                .ForMember(d => d.Id, t => t.Ignore())
                .ForMember(d => d.CreatedDate, t => t.Ignore())
                .ForMember(d => d.UpdatedDate, t => t.Ignore())
                .ForMember(d => d.CreatorId, t => t.Ignore())
                .ForMember(d => d.Pubished, t => t.Ignore())
                .ForMember(d => d.Category, t => t.Ignore())
                .ForMember(d => d.ProductImages, t => t.Ignore());


            //ProductImage
            CreateMap<ProductImageDto, ProductImage>();
            CreateMap<ProductImageInfoDto, ProductImage>()
                .ForMember(d => d.Product, t => t.Ignore());
            CreateMap<UpdateProductImageDto, ProductImage>()
                .ForMember(d => d.Id, t => t.Ignore())
                .ForMember(d => d.CreatedDate, t => t.Ignore())
                .ForMember(d => d.UpdatedDate, t => t.Ignore())
                .ForMember(d => d.CreatorId, t => t.Ignore())
                .ForMember(d => d.Pubished, t => t.Ignore())
                .ForMember(d => d.ProductId, t => t.Ignore());



            //Rating
            CreateMap<RatingDto, Rating>();
            CreateMap<RatingInfoDto, Rating>()
                .ForMember(d => d.User, t => t.Ignore())
                .ForMember(d => d.Product, t => t.Ignore());
            CreateMap<UpdateRatingDto, Rating>()
                .ForMember(d => d.Id, t => t.Ignore())
                .ForMember(d => d.UpdatedDate, t => t.Ignore())
                .ForMember(d => d.CreatedDate, t => t.Ignore())
                .ForMember(d => d.CreatorId, t => t.Ignore())
                .ForMember(d => d.User, t => t.Ignore())
                .ForMember(d => d.Product, t => t.Ignore());


            //Role
            CreateMap<RoleDto, Role>();
            CreateMap<RoleInfoDto, Role>()
                .ForMember(d => d.User, t => t.Ignore());
            CreateMap<UpdateRoleDto, Role>()
                .ForMember(d => d.Id, t => t.Ignore())
                .ForMember(d => d.UpdatedDate, t => t.Ignore())
                .ForMember(d => d.CreatedDate, t => t.Ignore())
                .ForMember(d => d.CreatorId, t => t.Ignore())
                .ForMember(d => d.User, t => t.Ignore());


            //User
            CreateMap<UserDto, User>();
            CreateMap<UserInfoDto, User>()
                .ForMember(d => d.Roles, t => t.Ignore())
                .ForMember(d => d.Orders, t => t.Ignore())
                .ForMember(d => d.UserAccount, t => t.Ignore());
            CreateMap<UpdateUserDto, User>()
                .ForMember(d => d.Id, t => t.Ignore())
                .ForMember(d => d.UpdatedDate, t => t.Ignore())
                .ForMember(d => d.CreatedDate, t => t.Ignore())
                .ForMember(d => d.CreatorId, t => t.Ignore())
                .ForMember(d => d.Roles, t => t.Ignore())
                .ForMember(d => d.Orders, t => t.Ignore())
                .ForMember(d => d.UserAccount, t => t.Ignore());


            //UserAccount
            CreateMap<UserAccountDto, UserAccount>()
                 .ForMember(d => d.User, t => t.Ignore());
            CreateMap<UserAccountInfoDto, UserAccount>()
                 .ForMember(d => d.User, t => t.Ignore());
            CreateMap<UpdateUserAccountDto, UserAccount>()
                .ForMember(d => d.Id, t => t.Ignore())
                .ForMember(d => d.UpdatedDate, t => t.Ignore())
                .ForMember(d => d.CreatedDate, t => t.Ignore())
                .ForMember(d => d.CreatorId, t => t.Ignore())
                .ForMember(d => d.User, t => t.Ignore())
                .ForMember(d => d.UserId, t => t.Ignore())
                .ForMember(d => d.UserName, t => t.Ignore());
        }

        private void FromDataAccessorLayer()
        {
            //Address
            CreateMap<Address, AddressInfoDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Address, AddAddressDto>();


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
