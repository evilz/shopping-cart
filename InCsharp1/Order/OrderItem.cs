namespace CsharpEvolve.Order
{
    public class OrderItem
    {
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get;  }
        public int Quantity { get;  }
    }
}