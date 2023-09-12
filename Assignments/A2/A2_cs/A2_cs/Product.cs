namespace A2_cs
{
    public class Product
	{
		public ID Id;
		public string Name;
		public int Price;
		public double Rate;
		public Product(ID id , string name, int price, double rate)
		{
            Id = id;
            Name = name;
            Price = price;
            Rate = rate;
        }
        public ID id
        {
        get { return Id; }
        set { Id = value; }

        }
        public string name
        {
        get { return Name; }
        set { Name = value; }

        }
        public int price
        {
        get { return Price; }
        set { Price = value; }

        }
        public double rate
        {
        get { return Rate; }
        set { Rate = value; }

        }
    }
}

