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
    public partial class staff_1 : Form
    {
        Database db = new Database();
        public staff_1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;


            string myConnectionString = "Database=beauty_salon;Data Source=127.0.0.1;User Id=root;Password=1337";


            DataTable staff = new DataTable();

            MySqlConnection connection_staff = new MySqlConnection(myConnectionString);
            {
                MySqlCommand command = new MySqlCommand("select idstaff, name from staff\r\njoin staff_to_services on staff.idstaff = staff_to_services.id_staff\r\nwhere staff_to_services.id_service = @idservice", connection_staff);
                command.Parameters.Add("@idservice", MySqlDbType.VarChar).Value = services_1.id_service;
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(staff);
            }
            listBox1.DataSource = staff;
            listBox1.DisplayMember = "name";
            listBox1.ValueMember = "idstaff";
            listBox1.ClearSelected();
        }

        private void staff_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            button1.Visible = false;
        }
        public static int id_staff;

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Visible = true;
            button1.Visible = true;

            string myConnectionString = "Database=beauty_salon;Data Source=127.0.0.1;User Id=root;Password=1337";

            MySqlConnection staff_connection = new MySqlConnection(myConnectionString);

            MySqlCommand command_staff = new MySqlCommand("select positions.title from staff\r\njoin positions on staff.id_position = positions.idpositions where idstaff = @idstaff", staff_connection);
            command_staff.Parameters.Add("@idstaff", MySqlDbType.VarChar).Value = listBox1.SelectedValue;
            staff_connection.Open();

            String staff_post;

            staff_post = command_staff.ExecuteScalar().ToString();
            staff_connection.Close();

            label1.Text = staff_post;

            id_staff = (int)listBox1.SelectedValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            creating_service frm1 = new creating_service();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
