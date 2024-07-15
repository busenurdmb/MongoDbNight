using MongoDbNight.Dtos.OrderDtos;

namespace MongoDbNight.Services.OrderServices
{
    public interface IOrderService
    {
        Task<List<ResultOrderDto>> GetAllOrderAsync();
        Task CreateOrderAsync(CreateOrderDto productDto);
        Task UpdateOrderAsync(UpdateOrderDto productDto);
        Task DeleteOrderAsync(string id);
        Task<GetByIdOrderDto> GetByIdOrderAsync(string id);
        Task<List<ResultOrderWithCustomerWithProductDto>> ResultOrderWithCustomerWithProductDto();
    }
}
