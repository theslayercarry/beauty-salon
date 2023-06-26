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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace beauty_salon
{
    public partial class employees_prodoljenie : Form
    {
        Database db = new Database();
        public employees_prodoljenie()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;


            string myConnectionString = "Database=beauty_salon;Data Source=127.0.0.1;User Id=root;Password=1337";


            DataTable table_posts = new DataTable();

            MySqlConnection connection_posts = new MySqlConnection(myConnectionString);
            {
                MySqlCommand command = new MySqlCommand("select idpositions, title from positions", connection_posts);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(table_posts);
            }
            comboBox_post.DataSource = table_posts;
            comboBox_post.DisplayMember = "title";
            comboBox_post.ValueMember = "idpositions";
        }

        private void employees_prodoljenie_Load(object sender, EventArgs e)
        {
            comboBox_post.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("insert into staff (name, id_position, number_of_working_days, work_schedule_to, work_schedule_from, gender, date_of_admission) values\r\n(@name, @id_position, @number_of_working_days, @work_schedule_to, @work_schedule_from, @gender, now())", db.getConnection());
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox_name.Text;
            cmd.Parameters.Add("@id_position", MySqlDbType.VarChar).Value = comboBox_post.SelectedValue;
            cmd.Parameters.Add("@number_of_working_days", MySqlDbType.VarChar).Value = textBox_count_days.Text;
            cmd.Parameters.Add("@work_schedule_to", MySqlDbType.VarChar).Value = maskedTextBox_work_to.Text;
            cmd.Parameters.Add("@work_schedule_from", MySqlDbType.VarChar).Value = maskedTextBox_work_from.Text;
            cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = comboBox_gender.Text;



            db.openConnection();
            if (textBox_count_days.TextLength < 1 || textBox_name.TextLength < 1 || maskedTextBox_work_from.Text == "  :" || maskedTextBox_work_to.Text == "  :" || comboBox_post.Text == "" || comboBox_gender.Text == "")
            {
                MessageBox.Show("1.Введите ФИО сотрудника\r\n" +
                    "2.Выберите должность\r\nДругие ошибки выделены ниже:\r\n\n" +
                    "3.Введите количество рабочих дней\r\n" +
                    "4.Выберите пол сотрудника\r\n" +
                    "5.Введите график работы", "Несоответствие форме добавления сотрудника\r\n");
            }
            else if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Сотрудник '" + textBox_name.Text + "' успешно добавлен.", "Добавление сотрудника...");

                db.closeConnection();

                this.Close();
            }
            else
            {
                MessageBox.Show("Произошла ошибка при добавлении сотрудника.", "Ошибка при добавлении...");
            }
        }

        private void textBox_count_days_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (number != 8 && !Char.IsLetter(number) && number != 32)
            {
                e.Handled = true;
            }
        }
    }
}
