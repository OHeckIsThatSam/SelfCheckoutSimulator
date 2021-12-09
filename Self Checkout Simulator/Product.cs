using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    abstract class Product
    {
        // Attributes
        int barcode;b
        string name;
        int weightInGrams;

        // Constructor
        public Product(int barcode, string name, int weightInGrams)
        {
            this.barcode = barcode;
            this.name = name;
            this.weightInGrams = weightInGrams;
        }

        // Operations

        public abstract int CalculatePrice();

        public string GetName()
        {
            return name;
        }

        public int GetBarcode()
        {
            return barcode;
        }

        public int GetWeight()
        {
            return weightInGrams;
        }

        public void SetWeight(int weight)
        {
            weightInGrams = weight;
        }
    }

    class PackagedProduct : Product
    {
        // Attributes
        int priceInPence;

        // Constructor
        public PackagedProduct(int barcode, string name, int priceInPence, int weightInGrams): base (barcode, name, weightInGrams)
        {
            this.priceInPence = priceInPence;
        }

        // Operations
        public override int CalculatePrice()
        {
            return priceInPence;
        }
    }
}