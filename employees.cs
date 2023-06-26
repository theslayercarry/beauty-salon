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
    public partial class employees : Form
    {

        Database db = new Database();
        public employees()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void employees_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid_staff(dataGridView1);
            dataGridView1.ClearSelection();
        }
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("idstaff", "id");
            dataGridView1.Columns.Add("name", "ФИО");
            dataGridView1.Columns.Add("post", "Должность");
            dataGridView1.Columns.Add("factor_of_utility", "Ставка");
            dataGridView1.Columns.Add("salary", "Заработная плата $");
            dataGridView1.Columns.Add("work_graphic", "График работы");
            dataGridView1.Columns.Add("number_of_working_days", "Количество рабочих дней");
            dataGridView1.Columns.Add("date_of_admission", "Дата начала работы");
            dataGridView1.Columns[1].Width = 195;
            dataGridView1.Columns[2].Width = 140;
            dataGridView1.Columns[3].Width = 130;
            dataGridView1.Columns[4].Width = 202;
            dataGridView1.Columns[5].Width = 192;
            dataGridView1.Columns[6].Width = 150;
            dataGridView1.Columns[7].Width = 180;

        }

        private void ReadSingleRow_staff(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetDateTime(7));

        }

        private void RefreshDataGrid_staff(DataGridView dwg)
        {
            dwg.Rows.Clear();
            MySqlCommand command = new MySqlCommand("select idstaff, name, positions.title, factor_of_utility, positions.salary, concat_ws(\" до \", work_schedule_to, work_schedule_from) as 'graphic', number_of_working_days, date_of_admission from staff\r\njoin positions on staff.id_position = positions.idpositions", db.getConnection());
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_staff(dwg, reader);
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            employees_prodoljenie frm1 = new employees_prodoljenie();
            this.Hide();
            frm1.ShowDialog();

            RefreshDataGrid_staff(dataGridView1);
            dataGridView1.ClearSelection();

            this.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            staff_to_services frm1 = new staff_to_services();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }
    }
}
