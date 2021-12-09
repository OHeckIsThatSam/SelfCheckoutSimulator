using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    static class ProductsDAO
    {
        // NOTE: we are creating all the data here. in reality this collection
        // would be filled with objects based on data loaded from a database 
        private static List<Product> Products = new List<Product>
        {
            // barcode, name, price, weight in grams
            new PackagedProduct(102397, "Bacon", 209, 300),
            new PackagedProduct(124567, "Cheese", 119, 150),
            new PackagedProduct(193467, "Toothpaste", 109, 75),
            new PackagedProduct(207545, "BBQ Sauce", 149, 100),
            new PackagedProduct(274563, "Bread", 79, 500),
            new PackagedProduct(345692, "Cat Food", 249, 1000),
            new PackagedProduct(367594, "Marmite", 225, 115),
            new PackagedProduct(490732, "Butter", 99, 500),
            new PackagedProduct(654347, "Eggs", 129, 400),
            new PackagedProduct(600234, "Pasta", 99, 750),
            new PackagedProduct(734542, "Sour Cream", 100, 300),
            new PackagedProduct(874537, "Prawns", 209, 650),
            new PackagedProduct(893475, "Rice", 139, 600),
            new PackagedProduct(914374, "Rocket", 100, 100),
            new PackagedProduct(923534, "Pizza", 109, 600),
        };

        public static Product SearchUsingBarcode(int barcode)
        {
            return Products.Find(p => p.GetBarcode() == barcode);
        }

        public static int GetRandomProductBarcode()
        {
            // filter the products to get only packaged items
            var products = Products.ToList();

            // return a random one
            return products[new Random().Next(products.Count)].GetBarcode();
        }
    }
}