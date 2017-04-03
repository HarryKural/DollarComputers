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
    public partial class OrderForm : Form
    {
        public ProductInfoForm productInfoForm { get; set; }

        public OrderForm()
        {
            InitializeComponent();
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
                case "Back":
                    // Instantiate an object to the next form
                    ProductInfoForm productInfoForm = new ProductInfoForm(null);

                    // Pass a reference to the current form to the next form
                    productInfoForm.orderForm = this;

                    // Show the next form
                    productInfoForm.Show();

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

                case "Finish":
                    DialogResult finish = MessageBox.Show("Thank you for your business." + Environment.NewLine + "Your order will be processed in 7 - 10 business days.", "Thank You!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (finish == DialogResult.OK)
                    {
                        Application.Exit();
                    }
                    break;
            }
        }

        /// <summary>
        /// This method displays a message box when print clicked from menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Printing... Your selection is in process to print.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// This method shares the event handler as of back button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackButton.PerformClick();
        }

        /// <summary>
        /// This method shares the event handler as of Cancel button to exit the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CancelButton.PerformClick();
        }

        /// <summary>
        /// Shows about form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();

            aboutForm.ShowDialog();
        }
    }
}
