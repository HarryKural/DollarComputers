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
    public partial class SelectForm : Form
    {
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
    }
}
