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
    public partial class Driver : Form
    {
        public string username = "name";
        public string[] cars = new string[10];
        public Driver()
        {
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i] = "car";
            }
            InitializeComponent();
        }

        public Driver(string newName)
        {
            username = newName;

            for (int i = 0; i < cars.Length; i++)
            {
                cars[i] = "car";
            }

            InitializeComponent();
        }

        private void btnWaiting_Click(object sender, EventArgs e)
        {
            var database = new SqlServerDataRepository();
            database.RiderWaiting(dataGridView1);
            dataGridView1.Show();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }

        private void btnMyRiders_Click(object sender, EventArgs e)
        {

        }
    }
}
