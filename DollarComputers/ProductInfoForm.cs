﻿using System;
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

        public ProductInfoForm()
        {
            InitializeComponent();
        }
    }
}
