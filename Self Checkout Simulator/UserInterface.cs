using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Self_Checkout_Simulator
{
    public partial class UserInterface : Form
    {
        // Attributes
        SelfCheckout selfCheckout;
        BarcodeScanner barcodeScanner;
        BaggingAreaScale baggingAreaScale;
        ScannedProducts scannedProducts;

        // Constructor
        public UserInterface()
        {
            InitializeComponent();

            // NOTE: This is where we set up all the objects,
            // and create the various relationships between them.

            baggingAreaScale = new BaggingAreaScale();
            scannedProducts = new ScannedProducts();
            barcodeScanner = new BarcodeScanner();
            selfCheckout = new SelfCheckout(baggingAreaScale, scannedProducts);
            barcodeScanner.LinkToSelfCheckout(selfCheckout);
            baggingAreaScale.LinkToSelfCheckout(selfCheckout);

            UpdateDisplay();
        }

        // Operations
        private void UserScansProduct(object sender, EventArgs e)
        {
            barcodeScanner.BarcodeDetected();

            UpdateDisplay();
        }

        private void UserPutsProductInBaggingAreaCorrect(object sender, EventArgs e)
        {
            // Passing the weight from the current product
            baggingAreaScale.WeightChangeDetected(selfCheckout.GetCurrentProduct().GetWeight());

            UpdateDisplay();
        }

        private void UserPutsProductInBaggingAreaIncorrect(object sender, EventArgs e)
        {
            // NOTE: We are pretending to put down an item with the wrong weight.
            // To simulate this we'll use a random number, here's one for you to use.

            int weight = new Random().Next(20, 100);

            baggingAreaScale.WeightChangeDetected(weight);

            UpdateDisplay();
        }

        private void AdminOverridesWeight(object sender, EventArgs e)
        {
            baggingAreaScale.OverrideWeight();

            UpdateDisplay();
        }

        private void UserChoosesToPay(object sender, EventArgs e)
        {
            selfCheckout.UserPaid();

            UpdateDisplay();
        }

        void UpdateDisplay()
        {
            // If the weight is okay then the user needs to scan another item or pay.
            if (baggingAreaScale.IsWeightOk())
            {
                btnUserScansBarcodeProduct.Enabled = true;
                btnUserPutsProductInBaggingAreaCorrect.Enabled = false;
                btnUserPutsProductInBaggingAreaIncorrect.Enabled = false;
                btnAdminOverridesWeight.Enabled = false;

                // If the user hasn't scanned any products disable the pay button
                // Else allow the user to pay for the basket.
                if (scannedProducts.GetProducts().Count == 0)
                {
                    lblScreen.Text = "Scan an item.";
                    btnUserChooseToPay.Enabled = false;
                }
                else
                { 
                    lblScreen.Text = "Scan an item or pay.";
                    btnUserChooseToPay.Enabled = true;
                }
            }
            // TO DO; NOT perfect
            else if (btnUserScansBarcodeProduct.Enabled == true)
            {
                btnUserScansBarcodeProduct.Enabled = false;
                btnUserPutsProductInBaggingAreaCorrect.Enabled = true;
                btnUserPutsProductInBaggingAreaIncorrect.Enabled = true;
                btnUserChooseToPay.Enabled = false;
                btnAdminOverridesWeight.Enabled = false;

                lblScreen.Text = "Place the item in the bagging area.";
            }
            else
            {
                btnUserPutsProductInBaggingAreaCorrect.Enabled = false;
                btnUserPutsProductInBaggingAreaIncorrect.Enabled = false;
                btnAdminOverridesWeight.Enabled = true;

                lblScreen.Text = "Please wait, an assistant is on the way.";
            }

            // Refreshes labels
            lblBaggingAreaCurrentWeight.Text = Convert.ToDecimal(baggingAreaScale.GetCurrentWeight()).ToString("0.00");
            lblBaggingAreaExpectedWeight.Text = Convert.ToDecimal(baggingAreaScale.GetExpectedWeight()).ToString("0.00");
            lblTotalPrice.Text = "£" + (Convert.ToDecimal(scannedProducts.CalculatePrice()) / 100).ToString("0.00");

            // Refreshes the list box
            lbBasket.Items.Clear();
            foreach (var product in scannedProducts.GetProducts())
            {
                lbBasket.Items.Add("£" + (Convert.ToDecimal(product.CalculatePrice() / 100)).ToString("0.00") + " " + product.GetName());
            }
        }
    }
}