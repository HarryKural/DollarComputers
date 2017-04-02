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

        // Create a reference to the previous form
        public StartForm startForm { get; set; }
        public ProductInfoForm productInfoForm { get; set; }

        public SelectForm()
        {
            InitializeComponent();
        }

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
                    ProductInfoForm productInfoForm = new ProductInfoForm();

                    // Pass a reference to the current form to the next form
                    productInfoForm.selectForm = this;

                    // Show the next form
                    productInfoForm.Show();

                    // Hide the form
                    this.Hide();
                    break;
            }
        }

        private void _SelectForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dollarComputersDataSet.products' table. You can move, or remove it, as needed.
            // this.productsTableAdapter.Fill(this.dollarComputersDataSet.products);

            try
            {
                // selecting all the products from the Products DB
                var ProductsList = (from Products in ProductsDB.products
                                    select Products).ToList();
                HardwareListDataGridView.DataSource = ProductsList;
            }
            catch(Exception exception)
            {
                MessageBox.Show("You are unable to connect to the database.", "Error: Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(exception.Message);
            }
        }

        private void _hardwareListDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (HardwareListDataGridView.SelectedRows.Count > 0)
            {
                YourSelectionTextBox.Text = HardwareListDataGridView.SelectedRows[0].Cells[2].Value.ToString() + " " +
                                            HardwareListDataGridView.SelectedRows[0].Cells[3].Value.ToString() + "   Priced at: $" +
                                            HardwareListDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            }
        }
    }
}
