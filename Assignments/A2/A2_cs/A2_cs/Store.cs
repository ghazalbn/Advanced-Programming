using System.Collections.Generic;

namespace A2_cs
{
    public class Store
    {
        public string Name;
        public List<Category> Categories;
        public List<Cart> Carts;
        public Store(string name, List<Category> categories, List<Cart> carts)
        {
            Name = name;
            Categories = categories;
            Carts = carts;
        }
        public void AddCart(Cart c)
        {
            Carts.Add(c);
        }
        public void AddCategory(Category c)
        {
            Categories.Add(c);
        }

        public Product Bestselling()
        {
            Product mp = Categories[0].products[0];
            int f = 0;
            foreach (Category c in Categories)
            {
                foreach(Product p in c.products)
                {
                    int d = 0;
                    foreach (Cart c1 in Carts)
                    {
                        foreach (Product p1 in c1.products)
                        {
                            if(p == p1) d++;
                        }
                    }
                    if(d > f){
                    f = d;
                    mp = p;
                    }
                }
            }
            
            return mp;
        }
        public Product MostPopular()
        {
            Product mp = Categories[0].products[0];
            double mrate = Categories[0].products[0].rate; 
            foreach (Category c in Categories)
            {
                foreach(Product p in c.products)
                {
                    if(p.rate > mrate){
                    mrate = p.rate;
                    mp = p;
                    }
                }
            }
            return mp;
        }
        public string  name
        {
        get { return Name; }
        set { Name = value; }
        }
        public List<Category> categories
        {
        get { return Categories; }
        set { Categories = value; }
        }
        public List<Cart> carts
        {
        get { return Carts; }
        set { Carts = value; }
        }
    }
}

