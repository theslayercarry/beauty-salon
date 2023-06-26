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
    public partial class main_page : Form
    {
        Database db = new Database();
        public main_page()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;


            List<choice> choices = new List<choice>
            {
            new choice { id=1, title="Сотрудники"},
            new choice { id=2, title="Клиенты"},
            new choice { id=3, title="Услуги"},
            new choice { id=4, title="Записи"},
            };

            listBox1.DataSource = choices;
            listBox1.DisplayMember = "title";
            listBox1.ValueMember = "id";
            listBox1.ClearSelected();
        }
        String title, location, phone, email, worked_hours;
        private void employees_info_Load(object sender, EventArgs e)
        {
            string myConnectionString = "Database=beauty_salon;Data Source=127.0.0.1;User Id=root;Password=1337";

            MySqlConnection bs_title_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_bs_title = new MySqlCommand("select title from beauty_salon where idbeauty_salon = 1", bs_title_connection);
            bs_title_connection.Open();

            title = command_bs_title.ExecuteScalar().ToString();
            label_title.Text = title;
            bs_title_connection.Close();


            MySqlConnection bs_location_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_bs_location = new MySqlCommand("select location from beauty_salon where idbeauty_salon = 1", bs_location_connection);
            bs_location_connection.Open();

            location = command_bs_location.ExecuteScalar().ToString();
            label_location.Text = location;
            bs_location_connection.Close();


            MySqlConnection bs_phone_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_bs_phone = new MySqlCommand("select phone from beauty_salon where idbeauty_salon = 1", bs_phone_connection);
            bs_phone_connection.Open();

            phone = command_bs_phone.ExecuteScalar().ToString();
            label_phone.Text = "+" + phone;
            bs_phone_connection.Close();


            MySqlConnection bs_email_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_bs_email = new MySqlCommand("select email from beauty_salon where idbeauty_salon = 1", bs_email_connection);
            bs_email_connection.Open();

            email = command_bs_email.ExecuteScalar().ToString();
            label_email.Text = email;
            bs_email_connection.Close();

            MySqlConnection bs_worked_hours_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_bs_worked_hours = new MySqlCommand("select concat_ws(\" до \", work_schedule_from, work_schedule_to) from beauty_salon where idbeauty_salon = 1", bs_worked_hours_connection);
            bs_worked_hours_connection.Open();

            worked_hours = command_bs_worked_hours.ExecuteScalar().ToString();
            label_worked_hours.Text = worked_hours;
            bs_worked_hours_connection.Close();

        }

        class choice
        {
            public int id { get; set; }
            public string title { get; set; }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if((int)listBox1.SelectedValue == 2)
            {
                customers frm1 = new customers();
                this.Hide();
                frm1.ShowDialog();
                this.Show();
            }
            else if((int)listBox1.SelectedValue == 1)
            {
                employees frm1 = new employees();
                this.Hide();
                frm1.ShowDialog();
                this.Show();
            }
            else if ((int)listBox1.SelectedValue == 3)
            {
                services_info frm1 = new services_info();
                this.Hide();
                frm1.ShowDialog();
                this.Show();
            }
            else if ((int)listBox1.SelectedValue == 4)
            {
                customers_to_staff frm1 = new customers_to_staff();
                this.Hide();
                frm1.ShowDialog();
                this.Show();
            }
        }
    }
}
