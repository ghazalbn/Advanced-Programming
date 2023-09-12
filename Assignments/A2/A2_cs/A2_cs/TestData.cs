using System.Collections.Generic;

namespace A2_cs
{
    public class TestData
    {
        public static Product Iphone6 = new Product(ID.Mobile, "IPhone6", 5_000_000, 8.3);
        public static Product SamsungGalaxy_A51 = new Product(ID.Mobile, "Galaxy A51", 4_599_000, 6.23);
        public static Product VOG_L29 = new Product(ID.Mobile, "VOG-L29", 9_910_000, 7.6);
        public static Product PureView_TA_1087 = new Product(ID.Mobile, "PureView TA 1087", 7_400_000, 7.3);
        public static Product Mi_Note_10_M1910F4G = new Product(ID.Mobile, "Mi Note 10 M1910F4G", 7_150_000, 7.64);
        public static Product Redmi_8_M1908C3IG = new Product(ID.Mobile, "Redmi 8 M1908C3IG", 2_499_000, 9.21);

        public static Product ZenBook_S13 = new Product(ID.Laptop, "ZenBook S13", 19_450_000, 5);
        public static Product Legion_Y545_D = new Product(ID.Laptop, "Legion Y545 - D", 24_350_000, 4.2);

        public static Product iPad_2018_4G = new Product(ID.Tablet, "iPad_2018_4G", 6_094_000, 9.1);
        public static Product Surface_Pro_7F = new Product(ID.Tablet, "Surface Pro 7 - F", 32_399_000, 8.8);

        public static List<Product> Mobiles = new List<Product>() {Iphone6,SamsungGalaxy_A51,VOG_L29
            ,PureView_TA_1087,Mi_Note_10_M1910F4G,Redmi_8_M1908C3IG};

        public static List<Product> Laptops = new List<Product>() {ZenBook_S13,Legion_Y545_D};
        public static List<Product> Tablets = new List<Product>() {iPad_2018_4G,Surface_Pro_7F};

        public static Category CategoryOfMobiles = new Category(ID.Mobile,Mobiles);
        public static Category CategoryOfLaptops = new Category(ID.Laptop,Laptops);
        public static Category CategoryOfTablets = new Category(ID.Tablet,Tablets);

    public static void Main()
    {

    }
    }
}
