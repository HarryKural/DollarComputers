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

using DollarComputers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DollarComputers
{
    public partial class SelectForm : Form
    {
        // Connect to the models
        ProductsContext ProductsDB = new ProductsContext();

        // Instantiate a list object
        List<string> hardware = new List<string>();

        // Create a reference to the previous form
        public StartForm startForm { get; set; }
        public ProductInfoForm productInfoForm { get; set; }

        public SelectForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method handles the button clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _buttonClickHandler(object sender, EventArgs e)
        {
            Button ClickHandler = sender as Button;

            switch (ClickHandler.Tag.ToString())
            {
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
                    ProductInfoForm productInfoForm = new ProductInfoForm(_getSelectedValue());

                    // Pass a reference to the current form to the next form
                    productInfoForm.selectForm = this;
                    
                    // Show the next form
                    productInfoForm.Show();

                    // Hide the form
                    this.Hide();
                    break;
            }
        }

        /// <summary>
        /// This method connects with the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _selectForm_Load(object sender, EventArgs e)
        {
            // this.productsTableAdapter.Fill(this.dollarComputersDataSet.products);

            /// Populating all the data from products table in DB
            /// Showing in the dataGridView
            try
            {
                // selecting all the products from the Products DB
                var ProductsList = (from Products in ProductsDB.products
                                    select Products).ToList();
                HardwareListDataGridView.DataSource = ProductsList;
            }
            /// Displays a message if something went wrong
            catch(Exception exception)
            {
                MessageBox.Show("You are unable to connect to the database.", "Error: Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// This method is used to display the selected row in the textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _hardwareListDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // this will work if any row is selected
            if (HardwareListDataGridView.SelectedRows.Count > 0)
            {
                YourSelectionTextBox.Text = HardwareListDataGridView.SelectedRows[0].Cells[2].Value.ToString() + " " +
                                            HardwareListDataGridView.SelectedRows[0].Cells[3].Value.ToString() + "   Priced at: $" +
                                            HardwareListDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            }


        }

        /// <summary>
        /// This method adds the data to list (hardware) which is needed to pass to other form
        /// </summary>
        private List<string> _getSelectedValue()
        {
            List<string> hardware = new List<string>();

            hardware.Add(HardwareListDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            hardware.Add(HardwareListDataGridView.SelectedRows[0].Cells[14].Value.ToString());
            hardware.Add(HardwareListDataGridView.SelectedRows[0].Cells[1].Value.ToString());
            hardware.Add(HardwareListDataGridView.SelectedRows[0].Cells[16].Value.ToString());
            hardware.Add(HardwareListDataGridView.SelectedRows[0].Cells[15].Value.ToString());
            hardware.Add(HardwareListDataGridView.SelectedRows[0].Cells[2].Value.ToString());
            hardware.Add(HardwareListDataGridView.SelectedRows[0].Cells[3].Value.ToString());
            hardware.Add(HardwareListDataGridView.SelectedRows[0].Cells[5].Value.ToString());
            hardware.Add(HardwareListDataGridView.SelectedRows[0].Cells[7].Value.ToString());
            hardware.Add(HardwareListDataGridView.SelectedRows[0].Cells[17].Value.ToString());
            hardware.Add(HardwareListDataGridView.SelectedRows[0].Cells[10].Value.ToString());
            hardware.Add(HardwareListDataGridView.SelectedRows[0].Cells[13].Value.ToString());
            hardware.Add(HardwareListDataGridView.SelectedRows[0].Cells[19].Value.ToString());
            hardware.Add(HardwareListDataGridView.SelectedRows[0].Cells[11].Value.ToString());
            hardware.Add(HardwareListDataGridView.SelectedRows[0].Cells[12].Value.ToString());
            hardware.Add(HardwareListDataGridView.SelectedRows[0].Cells[30].Value.ToString());

            return hardware;
        }
    }
}
