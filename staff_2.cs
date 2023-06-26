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
    public partial class staff_2 : Form
    {
        Database db = new Database();
        public staff_2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;


            string myConnectionString = "Database=beauty_salon;Data Source=127.0.0.1;User Id=root;Password=1337";


            DataTable staff = new DataTable();

            MySqlConnection connection_staff = new MySqlConnection(myConnectionString);
            {
                MySqlCommand command = new MySqlCommand("select idstaff, name from staff", connection_staff);
     
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(staff);
            }
            listBox1.DataSource = staff;
            listBox1.DisplayMember = "name";
            listBox1.ValueMember = "idstaff";
            listBox1.ClearSelected();
        }

        private void staff_2_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            button1.Visible = false;
        }

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

            staff_1.id_staff = (int)listBox1.SelectedValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            services_2 frm1 = new services_2();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }
    }
    
}
