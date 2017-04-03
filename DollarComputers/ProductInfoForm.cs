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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DollarComputers
{

    

    public partial class ProductInfoForm : Form
    {

        private List<string> _productDetails;

        // Create a reference to the previous form
        public StartForm startForm { get; set; }
        public SelectForm selectForm { get; set; }
        public OrderForm orderForm { get; set; }
        
        public ProductInfoForm(List<string> productDetails)
        {
            InitializeComponent();
            
            if (productDetails == null)
            {
                // Open file and read from file
                openToolStripMenuItem.PerformClick();
            } 
            else
            {
                _productDetails = productDetails;
            }

            _fillForm();

        }

        private void _fillForm()
        {
            ProductIDTextBox.Text = _productDetails[0];
            ConditionTextBox.Text = _productDetails[1];
            CostTextBox.Text = _productDetails[2];
            PlatformTextBox.Text = _productDetails[3];
            OSTextBox.Text = _productDetails[4];
            ManufacturerTextBox.Text = _productDetails[5];
            ModelTextBox.Text = _productDetails[6];
            MemoryTextBox.Text = _productDetails[7];
            LCDSizeTextBox.Text = _productDetails[8];
            HDDTextBox.Text = _productDetails[9];
            CPUBrandTextBox.Text = _productDetails[10];
            CPUNumberTextBox.Text = _productDetails[11];
            GPUTypeTextBox.Text = _productDetails[12];
            CPUTypeTextBox.Text = _productDetails[13];
            CPUSpeedTextBox.Text = _productDetails[14];
            WebCamTextBox.Text = _productDetails[15];
        }

        private void _readFromFile(Object sender, EventArgs e)
        {

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader fileReader = new StreamReader(openFileDialog.FileName);
                    for (int i = 0; i < _productDetails.Count; i++)
                    {
                        _productDetails.Add(fileReader.ReadLine());
                    }

                    fileReader.Close();

                    _fillForm();
                }
                catch (Exception ex)
                {
                    // catch ex
                    
                }
            }
            
        }


        private void _writeToFile(Object sender, EventArgs e)
        {

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter fileWriter = new StreamWriter(saveFileDialog.FileName);
                    for (int i = 0; i < _productDetails.Count; i++)
                    {
                        fileWriter.WriteLine(_productDetails[i]);
                    }

                    fileWriter.Close();
                }
                catch (Exception ex)
                {
                    // catch ex

                }
            }

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
                    OrderForm orderForm = new OrderForm(_productDetails);

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
