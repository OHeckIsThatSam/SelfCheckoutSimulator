using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    class BaggingAreaScale
    {
        // Attributes
        private int weight;
        private int expected;
        private int allowedDiffrence;

        SelfCheckout selfCheckout;

        // Operations
        public int GetCurrentWeight()
        {
            return weight;
        }

        public bool IsWeightOk()
        {
            // If the sum of weight and allowed difference is equal to expected then weight it ok. 
            if (weight + allowedDiffrence == expected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetExpectedWeight()
        {
            return expected;
        }

        public void SetExpectedWeight(int expected)
        {
            // Increments the expected weight by the expected weight of the next item
            this.expected = this.expected + expected;
        }

        public void OverrideWeight()
        {
            // Overrides the expected weight with the current weight in the bagging area
            expected = weight;
        }

        public void Reset()
        {
            weight = 0;
            expected = 0;
            allowedDiffrence = 0;
        }

        public void LinkToSelfCheckout(SelfCheckout sc)
        {
            selfCheckout = sc;
        }

        // NOTE: in reality the difference wouldn't be passed in here
        // the scale would detect the change and notify the self checkout
        public void WeightChangeDetected(int difference)
        {
            weight = weight + difference;
            selfCheckout.BaggingAreaWeightChanged();
        }
    }
}