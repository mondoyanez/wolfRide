using System;
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
    public partial class PassengerHome : Form
    {
        public PassengerHome()
        {
            InitializeComponent();
        }

        public PassengerHome(string name)
        {
            InitializeComponent();
            txtName.Text = name;
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            MessageBox.Show("funds added");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }

        private void btnCurrentBalance_Click(object sender, EventArgs e)
        {
            var database = new SqlServerDataRepository();

            var currentBalance = database.GetBalance(txtName.Text);
            MessageBox.Show("Current Balance: $" + currentBalance);
        }
    }
}
