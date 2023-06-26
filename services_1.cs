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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace beauty_salon
{
    public partial class services_1 : Form
    {
        Database db = new Database();
        int i = 0;
        public services_1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            string myConnectionString = "Database=beauty_salon;Data Source=127.0.0.1;User Id=root;Password=1337";


            DataTable services = new DataTable();

            MySqlConnection connection_services = new MySqlConnection(myConnectionString);
            {
                MySqlCommand command = new MySqlCommand("select idservices, title from services", connection_services);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(services);
            }
            listBox1.DataSource = services;
            listBox1.DisplayMember = "title";
            listBox1.ValueMember = "idservices";
            listBox1.ClearSelected();
   
        }
        public static int id_service;
        private void services_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            button1.Visible = false;
            dataGridView_description.Visible = false;
        }

        private void CreateColumns_description()
        {
            dataGridView_description.Columns.Add("description", "Описание");
            dataGridView_description.Columns[0].Width = 422;
        }

        private void ReadSingleRow_description(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetString(0));

        }

        private void RefreshDataGrid_description(DataGridView dwg)
        {
            dwg.Rows.Clear();
            MySqlCommand command = new MySqlCommand("select description from services where idservices = @idservice", db.getConnection());
            command.Parameters.Add("@idservice", MySqlDbType.VarChar).Value = listBox1.SelectedValue;
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_description(dwg, reader);
            }
            reader.Close();
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (i++ == 0)
            {
                CreateColumns_description();
            }
            RefreshDataGrid_description(dataGridView_description);
            dataGridView_description.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_description.ClearSelection();

            dataGridView_description.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            button1.Visible = true;

            label1.Text = listBox1.Text;

            string myConnectionString = "Database=beauty_salon;Data Source=127.0.0.1;User Id=root;Password=1337";

            MySqlConnection services_connection = new MySqlConnection(myConnectionString);

            MySqlCommand command_services = new MySqlCommand("select cost from services where idservices = @idservice", services_connection);
            command_services.Parameters.Add("@idservice", MySqlDbType.VarChar).Value = listBox1.SelectedValue;
            services_connection.Open();

            String service_cost;

            service_cost = command_services.ExecuteScalar().ToString();
            services_connection.Close();

            label2.Text = service_cost + " $";

            id_service = (int)listBox1.SelectedValue;
        }

        private void dataGridView_description_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                ((DataGridView)sender).SelectedCells[0].Selected = false;
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            staff_1 frm1 = new staff_1();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void dataGridView_description_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
