using LouisBurgers.Services.Implementations;
using LouisBurgers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LouisBurgers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BurgersController : ControllerBase
    {
        
        private readonly IBurgerService _burgerService; //definimos que Iburgerservice es un atributo que usara el controlador
        public BurgersController(IBurgerService burgerService) //constructor que inicializa las variables para el controlador
        //lo de arriba es como poner public [nombreConstructor] ([parametros que recibe empezando por tipo de dato que en este caso es una interfaz y seguido del nombre del parametro]
        {
            _burgerService = burgerService;
        }

        [HttpGet("burger", Name = "GetMenuRequest")] //este es el nombre de la ruta que tiene en el swagger
        public async Task<IActionResult> GetMenu() //GetMenu es el nombre de mi metodo dentro de este controlador
        {
            try
            {
                var burgers = await _burgerService.GetMenuDetailsAsync();
                return Ok(burgers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpGet("extras", Name = "GetExtrasRequest")]
        //este es el nombre de la ruta que tiene en el swagger
        public async Task<IActionResult> GetExtras() //GetMenu es el nombre de mi metodo dentro de este controlador
        {
            try
            {
                var extra = await _burgerService.GetExtrasDetailsAsync();
                return Ok(extra);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        
    }
}
