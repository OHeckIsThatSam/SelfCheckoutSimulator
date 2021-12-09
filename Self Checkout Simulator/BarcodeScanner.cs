using System;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    class BarcodeScanner
    {
        // Attributes
        private SelfCheckout selfCheckout;

        // Operations
        public void BarcodeDetected()
        {
            // NOTE: in reality BarcodeScanner would see a real barcode and convert
            // it to a number. We have to fake this. So we grab a random barcode
            // from the available products and pretend we saw that instead

            int barcode = ProductsDAO.GetRandomProductBarcode();

            selfCheckout.BarcodeWasScanned(barcode);
        }

        // membership deteted
        public void LinkToSelfCheckout(SelfCheckout selfCheckout)
        {
            this.selfCheckout = selfCheckout;
        }
    }
}