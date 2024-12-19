using System;
using LouisBurgers.Data;
using LouisBurgers.Models;
using LouisBurgers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LouisBurgers.Services.Implementations
{
    public class BurgerService : IBurgerService
    {
        private readonly LouisBurgersContext _context;

        public BurgerService(LouisBurgersContext context)
        {
            _context = context;
        }

        public async Task<List<Burgers>> GetMenuDetailsAsync()
        {
            return await _context.Burgers
                .FromSqlRaw("EXEC GetMenu")
                .ToListAsync();
        }

        public async Task<List<Extras>> GetExtrasDetailsAsync()
        {
            return await _context.extra
                .FromSqlRaw("EXEC GetExtras")
                .ToListAsync();
        }
        
        public async Task<Order> createOrderAsync(createOrderRequest createOrder)
        {
            if (createOrder == null || createOrder.Burger == null || !createOrder.Burger.Any())
            {
                throw new ArgumentException("Invalid data");
            }

            //create order
            var order = new Order
            {
                totalPrice = 0,
                //orderBurger = new List<orderBurger>()
            };

            //crear los registros de orderburger y asociarlos a la orden
            foreach (var Burger in createOrder.Burger)
            {
                var orderBurger = new orderBurger
                {
                    idBurger = Burger.idBurger,
                    idExtra = Burger.idExtra
                };
                order.orderBurger.Add(orderBurger); //agrega la hamburguesa y extra a la lista de orderBurger de la clase order
                var burgerPrice = await GetBurgerPriceAsync(Burger.idBurger);
                decimal extraPrice = 0;
                if (Burger.idExtra != null)
                {
                    extraPrice = await GetExtraPriceAsync(Burger.idExtra);
                }
                
                order.totalPrice += await calculateTotalPrice(burgerPrice, extraPrice);

            }
        //aGREGAR LA ORDEN al dbcontext
        _context.order.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }


        public async Task<int> GetBurgerPriceAsync(int idBurger)
        {
            var Burger = await _context.Burger
                .Where(ob => ob.idBurger == idBurger)
                .FirstOrDefaultAsync();

            var burgerPrice = Burger?.price ?? 0;
            return burgerPrice;
        }

        public async Task<decimal> GetExtraPriceAsync(int? idExtra)
        {
            var Extra = await _context.extra
                .Where(ob => ob.idExtra == idExtra)
                .FirstOrDefaultAsync();

            var extraPrice = Extra?.price ?? 0;
            return extraPrice;
        }

        public async Task<decimal> calculateTotalPrice(int burgerPrice, decimal extraPrice)
        {
            var totalPrice = burgerPrice + extraPrice;
            return totalPrice;
        }

    }
}
