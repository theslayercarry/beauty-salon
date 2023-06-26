using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace beauty_salon
{
    public partial class services_info_prodoljenie : Form
    {
        Database db = new Database();
        int selectedRow;
        public services_info_prodoljenie()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        String title, description, cost;
        private void services_info_prodoljenie_Load(object sender, EventArgs e)
        {
            string myConnectionString = "Database=beauty_salon;Data Source=127.0.0.1;User Id=root;Password=1337";

            MySqlConnection service_title_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_service_title = new MySqlCommand("select title from services where idservices = @idservice", service_title_connection);
            command_service_title.Parameters.Add("@idservice", MySqlDbType.VarChar).Value = services_info.id_services_info;
            service_title_connection.Open();

            title = command_service_title.ExecuteScalar().ToString();
            textBox_title.Text = title;
            service_title_connection.Close();


            MySqlConnection service_cost_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_service_cost = new MySqlCommand("select cost from services where idservices = @idservice", service_cost_connection);
            command_service_cost.Parameters.Add("@idservice", MySqlDbType.VarChar).Value = services_info.id_services_info;
            service_cost_connection.Open();

            cost = command_service_cost.ExecuteScalar().ToString();
            textBox_cost.Text = cost;
            service_cost_connection.Close();


            MySqlConnection service_description_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_service_description = new MySqlCommand("select description from services where idservices = @idservice", service_description_connection);
            command_service_description.Parameters.Add("@idservice", MySqlDbType.VarChar).Value = services_info.id_services_info;
            service_description_connection.Open();

            description = command_service_description.ExecuteScalar().ToString();
            service_description_connection.Close();


            CreateColumns_description();
            RefreshDataGrid_description(dataGridView1);
            dataGridView1.ClearSelection();

        }

        private void CreateColumns_description()
        {
            dataGridView1.Columns.Add("description", "Описание");
            dataGridView1.Columns[0].Width = 529;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();

            title = textBox_title.Text;
            cost = textBox_cost.Text;
            if(dataGridView1.Rows[0].Cells[0].Value == null)
            {
                description = "";
            }
            else
            description = dataGridView1.Rows[0].Cells[0].Value.ToString();


            MySqlCommand command = new MySqlCommand("update services set title = @title, cost = @cost, description = @description where idservices = @idservice", db.getConnection());
            command.Parameters.Add("@title", MySqlDbType.VarChar).Value = title;
            command.Parameters.Add("@cost", MySqlDbType.VarChar).Value = cost;
            command.Parameters.Add("@description", MySqlDbType.VarChar).Value = description;
            command.Parameters.Add("@idservice", MySqlDbType.Int32).Value = services_info.id_services_info;

            if (textBox_title.TextLength < 1 || textBox_cost.TextLength < 1 || description == "")
            {
                MessageBox.Show("1.Введите наименование услуги\r\n" +
                    "2.Введите стоимость услуги\r\n" +
                    "3.Введите описание услуги\r\n", "Несоответствие форме изменения записи");
            }
            else if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Данные успешно изменены.", "Изменение данных...");
                RefreshDataGrid_description(dataGridView1);
                dataGridView1.ClearSelection();
            }
            else
            {
                MessageBox.Show("Ошибка при изменении данных.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ReadSingleRow_description(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetString(0));

        }

        private void RefreshDataGrid_description(DataGridView dwg)
        {
            dwg.Rows.Clear();
            MySqlCommand command = new MySqlCommand("select description from services where idservices = @idservice", db.getConnection());
            command.Parameters.Add("@idservice", MySqlDbType.VarChar).Value = services_info.id_services_info;
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_description(dwg, reader);
            }
            reader.Close();

        }
    }
}
