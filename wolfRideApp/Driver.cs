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
        public Driver()
        {
            InitializeComponent();
        }

        public Driver(string newName)
        {
            username = newName;
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
            var database = new SqlServerDataRepository();
            database.MyRiders(username, dataGridView1);
            dataGridView1.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            var database = new SqlServerDataRepository();
            if (database.isAdmin(username))
            {
                this.Hide();
                Admin a = new Admin(username);
                a.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Access Denied, you are not an Admin!");
            }
        }
    }
}
