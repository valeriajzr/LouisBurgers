namespace LouisBurgers.Models
{
    public class Extras
    {
        //El sistema sabe que corresponden a mi BD porque en mi stored procedure puse AS idExtra, AS Extra...
        public int idExtra { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
    }
}
