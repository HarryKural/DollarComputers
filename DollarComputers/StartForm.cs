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

        public StartForm()
        {
            InitializeComponent();
        }

        private void _buttonClickHandler(object sender, EventArgs e)
        {
            Button ClickHandler = sender as Button;

            switch (ClickHandler.Tag.ToString())
            {
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

                case "Open":
                    // Instantiate an object to the next form
                    ProductInfoForm productInfoForm = new ProductInfoForm();

                    // Pass a reference to the current form to the next form
                    productInfoForm.startForm = this;

                    // Show the next form
                    productInfoForm.Show();

                    // Hide the form
                    this.Hide();
                    break;

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
