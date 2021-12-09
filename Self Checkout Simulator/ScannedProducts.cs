using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    class ScannedProducts
    {
        // Attributes
        private List<Product> products = new List<Product>();

        // Operations
        public List<Product> GetProducts()
        {
            return products;
        }

        public int CalculateWeight()
        { 
            // Returns the weight of the last item added to product list.
            return products.Last().GetWeight();
        }

        public int CalculatePrice()
        {
            // Iterates through the list of products adding the price 
            // of each product to the total price.

            int totalPrice = 0;

            foreach (var product in products)
            {
                totalPrice = totalPrice + product.CalculatePrice();
            }

            return totalPrice;
        }

        public void Reset()
        {
            products = new List<Product>();
        }

        public void Add(Product p)
        {
            products.Add(p);
        }

        public bool HasItems()
        {
            if (products.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
