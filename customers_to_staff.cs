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
    public partial class customers_to_staff : Form
    {
        Database db = new Database();
        int selectedRow;
        String m, staff, customer, service, time;
        public customers_to_staff()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void staff_to_services_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid_staff_to_services(dataGridView1);
            dataGridView1.ClearSelection();
        }
        public static int id_customers_to_staff;
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("idcustomers_to_staff", "id");
            dataGridView1.Columns.Add("staff", "Сотрудник");
            dataGridView1.Columns.Add("customer", "Клиент");
            dataGridView1.Columns.Add("service", "Название услуги");
            dataGridView1.Columns.Add("appointment_time", "Время записи");
            dataGridView1.Columns.Add("cost", "Стоимость услуги $");
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 170;
            dataGridView1.Columns[3].Width = 250;
            dataGridView1.Columns[4].Width = 215;
            dataGridView1.Columns[5].Width = 210;

        }

        private void ReadSingleRow_staff_to_services(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetDateTime(4), record.GetString(5));

        }

        private void RefreshDataGrid_staff_to_services(DataGridView dwg)
        {
            dwg.Rows.Clear();
            MySqlCommand command = new MySqlCommand("select idcustomers_to_staff, staff.name, customers.name, services.title, appointment_time, services.cost from customers_to_staff\r\njoin staff on customers_to_staff.id_staff = staff.idstaff\r\njoin customers on customers_to_staff.id_customer = customers.idcustomers\r\njoin services on customers_to_staff.id_service = services.idservices\r\norder by idcustomers_to_staff", db.getConnection());
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_staff_to_services(dwg, reader);
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
                m = i;

                staff = row.Cells[1].Value.ToString();
                customer = row.Cells[2].Value.ToString();
                service = row.Cells[3].Value.ToString();
                time = row.Cells[4].Value.ToString();

                id_customers_to_staff = Convert.ToInt32(i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (m != null)
            {
                db.openConnection();
                MySqlCommand command = new MySqlCommand("delete from customers_to_staff where idcustomers_to_staff = @idcustomers_to_staff", db.getConnection());
                command.Parameters.Add("@idcustomers_to_staff", MySqlDbType.VarChar).Value = id_customers_to_staff;
                command.ExecuteNonQuery();

                MessageBox.Show("Клиент:  " + customer + "\r\n" +
                   "Услуга:   " + service + "\r\n" +
                   "Мастер:  " + staff + "\r\n\n" +
                   "Время записи:  " + time + "\r\n\n" +
                   "\t\tЗапись успешно удалена.\t\t", "Удаление записи...");

                m = null;

                RefreshDataGrid_staff_to_services(dataGridView1);

                db.closeConnection();
                dataGridView1.ClearSelection();
            }
            else
                MessageBox.Show("Ни одна запись не выбрана.");
        }
    }
}
