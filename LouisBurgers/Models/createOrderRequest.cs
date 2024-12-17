namespace LouisBurgers.Models
{
    //todo esto es nuevo
    public class createOrderRequest
    {
        public decimal totalPrice { get; set; }
        public List<BurgerRequest> Burger {  get; set; } = new List<BurgerRequest>();  // Inicialización para evitar null
    }
}
