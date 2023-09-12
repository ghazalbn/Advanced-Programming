using System.Collections.Generic;

namespace A2_cs
{
    public class Category
	{
		public ID Id;
		public List<Product> Products;
		public Category(ID id, List<Product> products)
		{
            Id = id;
            Products = products;
        }
        public void AddProduct(Product p)
		{
            if(p.id == this.id)
                Products.Add(p);
        }
        public List<Product> FilterByPrice(int lower,int upper)
		{
            List<Product> L = new List<Product>();
            foreach(Product p in Products)
            {
                if(p.price < upper && p.price > lower)
                    L.Add(p);
            }
            return L;
        }
        public ID id
        {
        get { return Id; }
        set { Id = value; }

        }
        public List<Product> products
        {
        get { return Products; }
        set { Products = products; }

        }
    }
}

