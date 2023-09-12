using System.Collections.Generic;

namespace A2_cs
{
    public class Cart
	{
		public string Owner;
		public List<Product> Products;
		public Cart(string owner, List<Product> products)
		{
			Owner = owner;
            Products = products;
		}
		public void AddProduct(Product p)
		{
            Products.Add(p);
        }
        public long CalculatePrice()
		{
            int price = 0;
            foreach(Product p in Products)
            {
                price += p.price;
            }
            return price;
        }
        public string owner
        {
        get { return Owner; }
        set { Owner = value; }
        }
        public List<Product> products
        {
        get { return Products; }
        set { Products = value; }

        }
    }
}

