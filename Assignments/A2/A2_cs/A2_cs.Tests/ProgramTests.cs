using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace A2_cs.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void ProductConstructorTest()
        {
            Assert.AreEqual(TestData.Iphone6.Id, ID.Mobile);
            Assert.AreEqual(TestData.SamsungGalaxy_A51.Id, ID.Mobile);

            Assert.AreEqual(TestData.ZenBook_S13.Id, ID.Laptop);
            Assert.AreEqual(TestData.Legion_Y545_D.Id, ID.Laptop);

            Assert.AreEqual(TestData.iPad_2018_4G.Id, ID.Tablet);
            Assert.AreEqual(TestData.Surface_Pro_7F.Id, ID.Tablet);

            Assert.AreEqual(TestData.Iphone6.Price, 5_000_000);
            Assert.AreEqual(TestData.SamsungGalaxy_A51.Price, 4_599_000);

            Assert.AreEqual(TestData.ZenBook_S13.Price, 19_450_000);
            Assert.AreEqual(TestData.Legion_Y545_D.Price, 24_350_000);

            Assert.AreEqual(TestData.iPad_2018_4G.Price, 6_094_000);
            Assert.AreEqual(TestData.Surface_Pro_7F.Price, 32_399_000);

        }
        [TestMethod()]
        public void CategoryConstructorTest()
        {
            Assert.AreEqual(TestData.CategoryOfMobiles.Id, ID.Mobile);
            Assert.AreEqual(TestData.CategoryOfLaptops.Id, ID.Laptop);
            Assert.AreEqual(TestData.CategoryOfTablets.Id, ID.Tablet);

            Assert.AreEqual(TestData.CategoryOfMobiles.Products[0].Name, "IPhone6");
            Assert.AreEqual(TestData.CategoryOfLaptops.Products[0].Name, "ZenBook S13");
            Assert.AreEqual(TestData.CategoryOfTablets.Products[0].Name, "iPad_2018_4G");
        }

        [TestMethod()]
        public void CategoryAddProductTest()
        {
            Category cat = new Category(ID.Mobile, new List<Product>());

            cat.AddProduct(TestData.Iphone6);
            cat.AddProduct(TestData.SamsungGalaxy_A51);
            cat.AddProduct(TestData.VOG_L29);

            Assert.AreEqual(cat.Products.Count, 3);
            Assert.AreEqual(cat.Products[2].Name, "VOG-L29");
            Assert.AreEqual(cat.Products[2].Price, 9_910_000);

            cat.AddProduct(new Product(ID.Laptop, "ROG-2060GTX", 23_910_000, 8.9));
            Assert.AreEqual(cat.Products.Count, 3);
            Assert.AreEqual(cat.Products[2].Name, "VOG-L29");
            Assert.AreEqual(cat.Products[2].Price, 9_910_000);
        }

        [TestMethod()]
        public void CategoryFilterByPriceTest()
        {
            Category cat = new Category(ID.Mobile, new List<Product>());

            cat.AddProduct(TestData.PureView_TA_1087);
            cat.AddProduct(TestData.SamsungGalaxy_A51);
            cat.AddProduct(TestData.VOG_L29);
            cat.AddProduct(TestData.Mi_Note_10_M1910F4G);

            List<Product> filtered = cat.FilterByPrice(7_000_000, 7_500_000);
            Assert.AreEqual(filtered.Count, 2);
            Assert.AreEqual(filtered[0].Name, "PureView TA 1087");
            Assert.AreEqual(filtered[1].Name, "Mi Note 10 M1910F4G");
        }

        [TestMethod()]
        public void CartConstructorTest()
        {
            Cart cart = new Cart("Amir Eslami", TestData.Mobiles);

            Assert.AreEqual(cart.Owner, "Amir Eslami");
            Assert.AreEqual(cart.Products.Count, 6);
            Assert.AreEqual(cart.Products[2].Price, 9_910_000);
            Assert.AreEqual(cart.Products[3].Rate, 7.3);
        }

        [TestMethod()]
        public void CartAddProductTest()
        {
            Cart cart = new Cart("Amirali Masoumi", new List<Product>());
            cart.AddProduct(TestData.Legion_Y545_D);
            cart.AddProduct(TestData.Redmi_8_M1908C3IG);
            cart.AddProduct(TestData.Iphone6);
            Assert.AreEqual(cart.Products.Count, 3);
            Assert.AreEqual(cart.Products[2].Name, "IPhone6");

        }

        [TestMethod()]
        public void CartCalculatePriceTest()
        {
            Cart cart = new Cart("Amirali Masoumi", new List<Product>());
            cart.AddProduct(TestData.Legion_Y545_D);
            cart.AddProduct(TestData.Surface_Pro_7F);
            cart.AddProduct(TestData.Iphone6);
            Assert.AreEqual(cart.CalculatePrice(), 61749000);
        }

        [TestMethod()]
        public void StoreConstructorTest()
        {
            List<Category> categories = new List<Category>()
            {
                TestData.CategoryOfMobiles,
                TestData.CategoryOfLaptops,
                TestData.CategoryOfTablets
            };
            List<Cart> carts = new List<Cart>() {
                new Cart("Amirali Masoumi", new List<Product>() { TestData.Legion_Y545_D, TestData.Surface_Pro_7F, TestData.Iphone6 }),
                new Cart("Ramtin Ehsani", new List<Product>() { TestData.PureView_TA_1087, TestData.ZenBook_S13, TestData.Redmi_8_M1908C3IG })
            };
            Store store = new Store("APkala", categories, carts);
            Assert.AreEqual(store.Name.Length, 6);
            Assert.AreEqual(store.Carts[0].Owner, "Amirali Masoumi");
            Assert.AreEqual(store.Categories.Count, 3);
            Assert.AreEqual(store.Carts.Count, 2);
        }
        [TestMethod()]
        public void StoreAddCartTest()
        {
            List<Category> categories = new List<Category>()
            {
                TestData.CategoryOfMobiles,
                TestData.CategoryOfLaptops,
                TestData.CategoryOfTablets
            };
            List<Cart> carts = new List<Cart>() {
                new Cart("Amirali Masoumi", new List<Product>() { TestData.Legion_Y545_D, TestData.Surface_Pro_7F, TestData.Iphone6 }),
                new Cart("Ramtin Ehsani", new List<Product>() { TestData.PureView_TA_1087, TestData.ZenBook_S13, TestData.Redmi_8_M1908C3IG })
            };
            Store store = new Store("APkala", categories, carts);
            store.AddCart(new Cart("Siavash Sepehri", new List<Product>() { TestData.Mi_Note_10_M1910F4G, TestData.SamsungGalaxy_A51 }));
            Assert.AreEqual(store.Carts.Count, 3);
            Assert.AreEqual(store.Carts[2].CalculatePrice(), 11749000);
            Assert.AreEqual(store.Carts[0].Products[1].Id, ID.Tablet);
        }

        [TestMethod()]
        public void StoreAddCategoryTest()
        {
            Store store = new Store("APkala", new List<Category>(), new List<Cart>());
            store.AddCategory(TestData.CategoryOfLaptops);
            store.AddCategory(TestData.CategoryOfMobiles);
            store.AddCategory(TestData.CategoryOfTablets);
            Assert.AreEqual(store.Carts.Count, 0);
            Assert.AreEqual(store.Categories.Count, 3);
            Assert.AreEqual(store.Categories[1].Id, ID.Mobile);
        }

        [TestMethod()]
        public void StoreBestsellingTest()
        {
            Store store = new Store("APkala", new List<Category>(), new List<Cart>());
            store.AddCategory(TestData.CategoryOfLaptops);
            store.AddCategory(TestData.CategoryOfMobiles);
            store.AddCategory(TestData.CategoryOfTablets);
            Assert.AreEqual(store.Categories[1].Products.Count, 6);

            Cart cart1 = new Cart("Mohammad Karimian", new List<Product>());
            cart1.AddProduct(TestData.Iphone6);
            cart1.AddProduct(TestData.Surface_Pro_7F);
            cart1.AddProduct(TestData.Mi_Note_10_M1910F4G);
            cart1.AddProduct(TestData.ZenBook_S13);

            Cart cart2 = new Cart("Ali Rahmani", new List<Product>());
            cart2.AddProduct(TestData.Redmi_8_M1908C3IG);
            cart2.AddProduct(TestData.Iphone6);

            Cart cart3 = new Cart("Abbas Karbaschi", new List<Product>());
            cart3.AddProduct(TestData.PureView_TA_1087);
            cart3.AddProduct(TestData.VOG_L29);
            cart3.AddProduct(TestData.SamsungGalaxy_A51);
            cart3.AddProduct(TestData.Iphone6);

            store.AddCart(cart1);
            store.AddCart(cart2);
            store.AddCart(cart3);

            Product p = store.Bestselling();
            Assert.AreEqual(p.Id, ID.Mobile);
            Assert.AreEqual(p.Price, 5000000);
        }
        [TestMethod()]
        public void StoreMostPopularTest()
        {
            Store store = new Store("APkala", new List<Category>(), new List<Cart>());
            store.AddCategory(TestData.CategoryOfLaptops);
            store.AddCategory(TestData.CategoryOfMobiles);
            store.AddCategory(TestData.CategoryOfTablets);
            Assert.AreEqual(store.Categories[1].Products.Count, 6);

            Cart cart1 = new Cart("Mohammad Karimian", new List<Product>());
            cart1.AddProduct(TestData.Iphone6);
            cart1.AddProduct(TestData.Surface_Pro_7F);
            cart1.AddProduct(TestData.Mi_Note_10_M1910F4G);
            cart1.AddProduct(TestData.ZenBook_S13);

            Cart cart2 = new Cart("Ali Rahmani", new List<Product>());
            cart2.AddProduct(TestData.Redmi_8_M1908C3IG);
            cart2.AddProduct(TestData.Iphone6);

            Cart cart3 = new Cart("Abbas Karbaschi", new List<Product>());
            cart3.AddProduct(TestData.PureView_TA_1087);
            cart3.AddProduct(TestData.VOG_L29);
            cart3.AddProduct(TestData.SamsungGalaxy_A51);
            cart3.AddProduct(TestData.Iphone6);

            store.AddCart(cart1);
            store.AddCart(cart2);
            store.AddCart(cart3);

            Product p = store.MostPopular();
            Assert.AreEqual(p.Id, ID.Mobile);
            Assert.AreEqual(p.Price, 2499000);
        }
    }
}