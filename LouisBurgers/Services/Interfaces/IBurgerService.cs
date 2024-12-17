using LouisBurgers.Models;

namespace LouisBurgers.Services.Interfaces
{
    public interface IBurgerService
    {
        Task<List<Burgers>> GetMenuDetailsAsync();
        Task<List<Extras>> GetExtrasDetailsAsync();
        Task<Order> createOrderAsync(createOrderRequest createOrder);
    }
}
