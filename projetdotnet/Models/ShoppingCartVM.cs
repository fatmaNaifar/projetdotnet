namespace projetdotnet.Models
{
    public class ShoppingCartVM
    {
        public IEnumerable<shoppingCart> ShoppingCartList { get; set; }
        public double OrderTotal { get; set; }

    }
}
