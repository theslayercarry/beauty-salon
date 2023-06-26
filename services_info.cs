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
    public partial class services_info : Form
    {
        Database db = new Database();
        int selectedRow;
        String m;
        public services_info()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void services_info_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid_services(dataGridView1);
            dataGridView1.ClearSelection();
        }
        public static int id_services_info;
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("idservices", "id");
            dataGridView1.Columns.Add("title", "Название услуги");
            dataGridView1.Columns.Add("description", "Описание");
            dataGridView1.Columns.Add("cost", "Стоимость $");
            dataGridView1.Columns[1].Width = 210;
            dataGridView1.Columns[2].Width = 580;
            dataGridView1.Columns[3].Width = 127;

        }

        private void ReadSingleRow_services(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetString(3));

        }

        private void RefreshDataGrid_services(DataGridView dwg)
        {
            dwg.Rows.Clear();
            MySqlCommand command = new MySqlCommand("select idservices, title, description, cost from services", db.getConnection());
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_services(dwg, reader);
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (m != null)
            {
                services_info_prodoljenie frm1 = new services_info_prodoljenie();
                this.Hide();
                frm1.ShowDialog();

                RefreshDataGrid_services(dataGridView1);
                dataGridView1.ClearSelection();

                this.Show();
                m = null;
            }
            else
                MessageBox.Show("Ни одна услуга не выбрана.");
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
                id_services_info = Convert.ToInt32(i);
            }
        }
    }
}
