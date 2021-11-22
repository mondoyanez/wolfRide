﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wolfRideApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCheckPassword_Click(object sender, EventArgs e)
        {
            var username = txtBoxUserName.Text;
            var password = txtBoxPassword.Text;

            if (username.Equals(string.Empty) || password.Equals(string.Empty))
            {
                MessageBox.Show("Must enter in a Username or Password");
            }
        }
    }
}