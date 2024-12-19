using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LouisBurgers.Models
{
    public class orderBurger
    {
        public int idOrder { get; set; }
        [JsonIgnore]
        public Order order { get; set; }
        public int idBurger { get; set; }
        public Burger burger { get; set; }
        public int? idExtra { get; set; }

    }
}
