using Azure.Core;
using LouisBurgers.Data;
using LouisBurgers.Models;
using LouisBurgers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LouisBurgers.Controllers
{
    public class orderBurgerController : ControllerBase
    {
        private readonly IBurgerService _burgerService; //definimos que Iburgerservice es un atributo que usara el controlador
        public orderBurgerController(IBurgerService burgerService) //constructor que inicializa las variables para el controlador
        //lo de arriba es como poner public [nombreConstructor] ([parametros que recibe empezando por tipo de dato que en este caso es una interfaz y seguido del nombre del parametro]
        {
            _burgerService = burgerService;
        }

        [HttpPost("createOrderRequest", Name = "createOrderRequest")]
        //este es el nombre de la ruta que tiene en el swagger
        /* Comento esto porque lo cambio por toda lo siguiente
        public async Task<IActionResult> CreateOrder([FromBody] orderBurger createOrder)
        {
            if (createOrder == null)
            {
                return BadRequest("Invalid request.");
            }

            try
            {
                int orderId = await _burgerService.createOrderAsync(createOrder);
                return CreatedAtAction(nameof(CreateOrder), new { id = orderId }, orderId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
         */
        public async Task<IActionResult> CreateOrder([FromBody] createOrderRequest createOrder)
        {
            if (createOrder == null || createOrder.Burger == null || !createOrder.Burger.Any())
            {
                return BadRequest ("Invalid data");
            }
            try 
            {
                var order = await _burgerService.createOrderAsync(createOrder);
                return Ok(order);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            
        }

    }
}
