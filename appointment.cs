using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beauty_salon
{
    public partial class appointment : Form
    {
        Database db = new Database();
        public appointment()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void appointment_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            services_1 frm1 = new services_1();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            staff_2 frm1 = new staff_2();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            services_1 frm1 = new services_1();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            staff_2 frm1 = new staff_2();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            main_page frm1 = new main_page();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void appointment_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void appointment_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
