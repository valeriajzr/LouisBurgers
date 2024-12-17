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
            return await _context.Extras
                .FromSqlRaw("EXEC GetExtras")
                .ToListAsync();
        }
        /*
        public async Task<int> createOrderAsync(orderBurger createOrder) //OrderBurgerRequest es el tipo de dato y createOrder es el nombre del dato
        {
            var order = new orderBurger
            {
                idBurger = createOrder.idBurger,
                idExtra = createOrder.idExtra
            };

            _context.orderBurger.Add(order);
            var orderSavedId = await _context.SaveChangesAsync();

            return orderSavedId; //devuelve el id del pedido que se acaba de crear
        }*/

        //nuevo y no entiendo nada
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
                order.orderBurger.Add(orderBurger);
                // Calcular el precio total (si es necesario)
                // Asegúrate de que tienes alguna lógica para obtener el precio de la hamburguesa y el extra
                //order.totalPrice += GetBurgerPrice(burger.idBurger) + (burger.idExtra.HasValue ? GetExtraPrice(burger.idExtra.Value) : 0);
            }
        //aGREGAR LA ORDEN al dbcontext
        _context.order.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
