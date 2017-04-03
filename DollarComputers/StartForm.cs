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
    public partial class StartForm : Form
    {
        // create a reference to the previous form
        public Form previousForm;

        // Constructor
        public StartForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method handles all the button clicks and perform their case accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _buttonClickHandler(object sender, EventArgs e)
        {
            Button ClickHandler = sender as Button;

            switch (ClickHandler.Tag.ToString())
            {
                /// Shows the selection form and hide start form
                case "New":
                    // Instantiate an object to the next form
                    SelectForm selectForm = new SelectForm();

                    // Pass a reference to the current form to the next form
                    selectForm.startForm = this;

                    // Show the next form
                    selectForm.Show();

                    // Hide the form
                    this.Hide();
                    break;

                /// Shows the ProductInfoForm and hide current form
                case "Open":
                    // Instantiate an object to the next form
                    ProductInfoForm productInfoForm = new ProductInfoForm(null);

                    // Pass a reference to the current form to the next form
                    productInfoForm.startForm = this;

                    // Show the next form
                    productInfoForm.Show();

                    // Hide the form
                    this.Hide();
                    break;

                /// Ask confirmation message to exit if OK
                case "Exit":
                    // showing up confirm message when cancel button clicked
                    DialogResult result = MessageBox.Show("Are You Sure you want to exit?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    // Closes the program if OK clicked
                    if (result == DialogResult.OK)
                    {
                        Application.Exit();
                    }
                    break;
            }
        }
    }
}
