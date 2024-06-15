using AdminApi.Dto.Request;
using AdminApi.Dto.Response;
using AdminApi.Models;
using AutoMapper;

namespace AdminApi.Dto.Mapper
{
    public class MyMapper:Profile
    {
        public MyMapper()
        {
            CreateMap<LoginRequest, User>();
            CreateMap<OrderDetail, OrderDetailResponse>()
           .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.image, opt => opt.MapFrom(src => src.Product.Image.ImageFilename));
            CreateMap<Order, OrderResponse>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.User!.Username))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => (decimal?)src.OrderDetails.Sum(od => od.Quantity * od.Price)));

            CreateMap<Ingredient, IngredientResponse>();


            ;
        }
    }
}
