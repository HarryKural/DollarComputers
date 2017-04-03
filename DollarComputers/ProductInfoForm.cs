// ______________________________________________________________________________________________
// App name:           Dollar Computers
// Author's name:      Harshit Sharma
// Student Number#:    200333254
// App Creation Date:  March 12, 2017
// Last Modified Date: April 02, 2017
// Professor:          Tom Tsiliopoulos
// Rapid Application Development - Assignment 4
// App description:    This application allows the user to buy a hardware product from the provided
//                     data and save that to a config file. Also, user can load file in the form.
// ________________________________________________________________________________________________

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DollarComputers
{
    public partial class ProductInfoForm : Form
    {
        // Create a reference to the previous form
        public StartForm startForm { get; set; }
        public SelectForm selectForm { get; set; }
        public OrderForm orderForm { get; set; }
        
        public ProductInfoForm(List<string> productDetails)
        {
            InitializeComponent();

            ProductIDTextBox.Text = productDetails[0];
            ConditionTextBox.Text = productDetails[14];
            CostTextBox.Text = productDetails[1];
            PlatformTextBox.Text = productDetails[16];
            OSTextBox.Text = productDetails[15];
            ManufacturerTextBox.Text = productDetails[2];
            ModelTextBox.Text = productDetails[3];
            MemoryTextBox.Text = productDetails[5];
            LCDSizeTextBox.Text = productDetails[7];
            HDDTextBox.Text = productDetails[17];
            CPUBrandTextBox.Text = productDetails[10];
            CPUNumberTextBox.Text = productDetails[13];
            GPUTypeTextBox.Text = productDetails[19];
            CPUTypeTextBox.Text = productDetails[11];
            CPUSpeedTextBox.Text = productDetails[12];
            WebCamTextBox.Text = productDetails[30];
        }

        /// <summary>
        /// This event handler handles all button clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _buttonClickHandler(object sender, EventArgs e)
        {
            Button ClickHandler = sender as Button;

            switch (ClickHandler.Tag.ToString())
            {
                case "Another":
                    // Instantiate an object to the next form
                    SelectForm selectForm = new SelectForm();

                    // Pass a reference to the current form to the next form
                    selectForm.productInfoForm = this;

                    // Show the next form
                    selectForm.Show();

                    // Hide the form
                    this.Hide();
                    break;

                case "Cancel":
                    // showing up confirm message when cancel button clicked
                    DialogResult result = MessageBox.Show("Are You Sure you want to exit?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    // Closes the program if OK clicked
                    if (result == DialogResult.OK)
                    {
                        Application.Exit();
                    }
                    break;

                case "Next":
                    // Instantiate an object to the next form
                    OrderForm orderForm = new OrderForm();

                    // Pass a reference to the current form to the next form
                    orderForm.productInfoForm = this;

                    // Show the next form
                    orderForm.Show();

                    // Hide the form
                    this.Hide();
                    break;
            }
        }

        /// <summary>
        /// This method performs job for menu exit item same as the cancel button by using perform click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CancelButton.PerformClick();
        }

        /// <summary>
        /// This method performs job for Select another product btn item same as the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _selectAnotherProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SelectAnotherProductButton.PerformClick();
        }
    }
}
