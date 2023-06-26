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
    public partial class creating_service : Form
    {
        public creating_service()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        public static DateTime date;
        public static String date_string;
        public static String time;



        private void label4_Click(object sender, EventArgs e)
        {
            time = label4.Text;

            confirmation_of_filling frm1 = new confirmation_of_filling();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            time = label6.Text;

            confirmation_of_filling frm1 = new confirmation_of_filling();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            time = label7.Text;

            confirmation_of_filling frm1 = new confirmation_of_filling();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            time = label8.Text;

            confirmation_of_filling frm1 = new confirmation_of_filling();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            time = label13.Text;

            confirmation_of_filling frm1 = new confirmation_of_filling();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            time = label9.Text;

            confirmation_of_filling frm1 = new confirmation_of_filling();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            time = label10.Text;

            confirmation_of_filling frm1 = new confirmation_of_filling();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            time = label11.Text;

            confirmation_of_filling frm1 = new confirmation_of_filling();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            time = label12.Text;

            confirmation_of_filling frm1 = new confirmation_of_filling();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            time = label14.Text;

            confirmation_of_filling frm1 = new confirmation_of_filling();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            time = label15.Text;

            confirmation_of_filling frm1 = new confirmation_of_filling();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            time = label16.Text;

            confirmation_of_filling frm1 = new confirmation_of_filling();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            time = label17.Text;

            confirmation_of_filling frm1 = new confirmation_of_filling();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            time = label19.Text;

            confirmation_of_filling frm1 = new confirmation_of_filling();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            time = label18.Text;

            confirmation_of_filling frm1 = new confirmation_of_filling();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            time = label20.Text;

            confirmation_of_filling frm1 = new confirmation_of_filling();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            time = label21.Text;

            confirmation_of_filling frm1 = new confirmation_of_filling();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value;
            date.GetDateTimeFormats('u');
            date_string = date.ToString("yyyy-MM-dd");
        }

        private void creating_service_Load(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value;
            date.GetDateTimeFormats('u');
            date_string = date.ToString("yyyy-MM-dd");
        }
    }
}
