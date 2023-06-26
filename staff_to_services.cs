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
    public partial class staff_to_services : Form
    {
        Database db = new Database();
        public staff_to_services()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;



            string myConnectionString = "Database=beauty_salon;Data Source=127.0.0.1;User Id=root;Password=1337";


            DataTable table_posts = new DataTable();

            MySqlConnection connection_posts = new MySqlConnection(myConnectionString);
            {
                MySqlCommand command = new MySqlCommand("select idstaff, name from staff", connection_posts);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(table_posts);
            }
            comboBox_staff.DataSource = table_posts;
            comboBox_staff.DisplayMember = "name";
            comboBox_staff.ValueMember = "idstaff";



            DataTable table_services = new DataTable();

            MySqlConnection connection_services = new MySqlConnection(myConnectionString);
            {
                MySqlCommand command = new MySqlCommand("select idservices, title from services", connection_services);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(table_services);
            }
            comboBox_service.DataSource = table_services;
            comboBox_service.DisplayMember = "title";
            comboBox_service.ValueMember = "idservices";


        }

        private void staff_to_services_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (check_records())
            {
                return;
            }
            var id_service = comboBox_service.SelectedValue;
            var id_staff = comboBox_staff.SelectedValue;


            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("insert into staff_to_services (id_staff, id_service) values (@id_staff, @id_service)", db.getConnection());
            command.Parameters.Add("@id_staff", MySqlDbType.Int32).Value = id_staff;
            command.Parameters.Add("@id_service", MySqlDbType.Int32).Value = id_service;


            db.openConnection();
            if (comboBox_staff.Text == "" || comboBox_service.Text == "")
            {
                MessageBox.Show("1. Выберите сотрудника\r\n2. Выберите услугу", "Несоответствие форме создания записи");
            }
            else if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Запись успешно создана.", "Добавление записи...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                db.closeConnection();

            }
            else
            {
                MessageBox.Show("Произошла ошибка при создании записи.", "Ошибка при добавлении записи", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private Boolean check_records()
        {
            var id_service = comboBox_service.SelectedValue;
            var id_staff = comboBox_staff.SelectedValue;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * from staff_to_services where id_staff = @id_staff and id_service = @id_service", db.getConnection());
            command.Parameters.Add("@id_staff", MySqlDbType.Int32).Value = id_staff;
            command.Parameters.Add("@id_service", MySqlDbType.Int32).Value = id_service;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Запись с заданными параметрами уже существует.");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
