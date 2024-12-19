using LouisBurgers.Models;

namespace LouisBurgers.Services.Interfaces
{
    public interface IBurgerService
    {
        Task<List<Burgers>> GetMenuDetailsAsync();
        Task<List<Extras>> GetExtrasDetailsAsync();
        Task<Order> createOrderAsync(createOrderRequest createOrder);
        Task<int> GetBurgerPriceAsync(int idBurger); //el primer int hace referencia al tipo de dato que nos va a devolver, entre parentesis los parametros que le pasamos
        Task<decimal> GetExtraPriceAsync(int? idExtra);
        Task<decimal> calculateTotalPrice(int burgerPrice, decimal extraPrice);
    }
}
