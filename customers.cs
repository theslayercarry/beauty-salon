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
    public partial class customers : Form
    {
        Database db = new Database();
        int selectedRow, j;
        public customers()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void customers_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid_customers(dataGridView1);
            dataGridView1.ClearSelection();
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("idcustomers", "id");
            dataGridView1.Columns.Add("name", "Имя");
            dataGridView1.Columns.Add("phone", "Телефон");
            dataGridView1.Columns.Add("email", "Email");
            dataGridView1.Columns.Add("date_of_joining", "Первое посещение");
            dataGridView1.Columns.Add("sum", "Всего потрачено $");
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 140;
            dataGridView1.Columns[3].Width = 190;
            dataGridView1.Columns[4].Width = 195;
            dataGridView1.Columns[5].Width = 194;

        }

        private void ReadSingleRow_customers(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetDateTime(4), record.GetString(5));

        }

        private void RefreshDataGrid_customers(DataGridView dwg)
        {
            dwg.Rows.Clear();
            MySqlCommand command = new MySqlCommand("select idcustomers, name, phone, email, date_of_joining, sum(services.cost) as 'sum' from customers \r\njoin customers_to_staff on customers.idcustomers = customers_to_staff.id_customer\r\njoin services on services.idservices = customers_to_staff.id_service\r\ngroup by customers_to_staff.id_customer\r\norder by idcustomers", db.getConnection());
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_customers(dwg, reader);
            }
            reader.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            String i;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                i = row.Cells[0].Value.ToString();
                j = Convert.ToInt32(i);

                string myConnectionString = "Database=beauty_salon;Data Source=127.0.0.1;User Id=root;Password=1337";

                DataTable table_customers_services = new DataTable();

                MySqlConnection connection_customers_services = new MySqlConnection(myConnectionString);
                {
                    MySqlCommand command = new MySqlCommand("select idservices, title from services\r\njoin customers_to_staff on customers_to_staff.id_service = services.idservices\r\nwhere customers_to_staff.id_customer = @id", connection_customers_services);
                    command.Parameters.Add("@id", MySqlDbType.VarChar).Value = j;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(table_customers_services);
                }

                listBox1.DataSource = table_customers_services;
                listBox1.DisplayMember = "title";
                listBox1.ValueMember = "idservices";
                listBox1.ClearSelected();
                listBox1.Refresh();
            }
        }
    }
}
