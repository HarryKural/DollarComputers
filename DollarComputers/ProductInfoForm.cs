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

        public ProductInfoForm()
        {
            InitializeComponent();
        }

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

        private void _exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CancelButton.PerformClick();
        }

        private void _selectAnotherProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SelectAnotherProductButton.PerformClick();
        }
    }
}
