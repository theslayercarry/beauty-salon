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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace beauty_salon
{
    public partial class confirmation_of_filling : Form
    {
        Database db = new Database();
        public confirmation_of_filling()
        {
            String picture;

            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBox_phone.Text = "+7 XXX XXX XX XX";
            textBox_phone.ForeColor = Color.DimGray;


            string myConnectionString = "Database=beauty_salon;Data Source=127.0.0.1;User Id=root;Password=1337";

            MySqlConnection picture_connection = new MySqlConnection(myConnectionString);
            picture_connection.Open();

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlCommand command_picture = new MySqlCommand("select gender from staff where idstaff = @idstaff", picture_connection);
            command_picture.Parameters.Add("@idstaff", MySqlDbType.VarChar).Value = staff_1.id_staff;

            picture = command_picture.ExecuteScalar().ToString();

            picture_connection.Close();
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (picture == "male")
            {
                pictureBox_male.Visible = true;
                pictureBox_female.Visible = false;
            }
            else
            {
                pictureBox_female.Visible = true;
                pictureBox_male.Visible = false;
            }


        }

        private void confirmation_of_filling_Load(object sender, EventArgs e)
        {

            textBox_phone.MaxLength = 11;
            textBox_email.MaxLength = 100;
            textBox_name.MaxLength = 100;

            string myConnectionString = "Database=beauty_salon;Data Source=127.0.0.1;User Id=root;Password=1337";

            MySqlConnection staff_connection = new MySqlConnection(myConnectionString);

            String name, post, service, service_cost;

            staff_connection.Open();


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlCommand command_name = new MySqlCommand("select name from staff where idstaff = @idstaff", staff_connection);
            command_name.Parameters.Add("@idstaff", MySqlDbType.VarChar).Value = staff_1.id_staff;

            name = command_name.ExecuteScalar().ToString();
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlCommand command_post = new MySqlCommand("select positions.title from staff\r\njoin positions on staff.id_position = positions.idpositions where idstaff = @idstaff", staff_connection);
            command_post.Parameters.Add("@idstaff", MySqlDbType.VarChar).Value = staff_1.id_staff;

            post = command_post.ExecuteScalar().ToString();
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            label_date.Text = creating_service.date_string;
            label_time.Text = creating_service.time;
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlCommand command_service = new MySqlCommand("select title from services where idservices = @idservice", staff_connection);
            command_service.Parameters.Add("@idservice", MySqlDbType.VarChar).Value = services_1.id_service;

            service = command_service.ExecuteScalar().ToString();
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlCommand command_service_cost = new MySqlCommand("select cost from services where idservices = @idservice", staff_connection);
            command_service_cost.Parameters.Add("@idservice", MySqlDbType.VarChar).Value = services_1.id_service;

            service_cost = command_service_cost.ExecuteScalar().ToString();
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            staff_connection.Close();

            label_service.Text = service;
            label_cost.Text = service_cost + " $";
            label_staff_name.Text = name;
            label_staff_post.Text = post;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String customer_name, customer_phone, customer_email;

            customer_name = textBox_name.Text;
            customer_phone = textBox_phone.Text;
            customer_email = textBox_email.Text;

            string myConnectionString = "Database=beauty_salon;Data Source=127.0.0.1;User Id=root;Password=1337";

            String customers_count; int id_customer;


            MySqlCommand cmd = new MySqlCommand("insert into customers (name, phone, email, date_of_joining) values (@customer_name, @customer_phone, @customer_email, now())", db.getConnection());
            cmd.Parameters.Add("@customer_name", MySqlDbType.VarChar).Value = customer_name;
            cmd.Parameters.Add("@customer_phone", MySqlDbType.VarChar).Value = customer_phone;
            cmd.Parameters.Add("@customer_email", MySqlDbType.VarChar).Value = customer_email;



            db.openConnection();
            if (textBox_name.TextLength < 1 || textBox_email.TextLength < 9 || textBox_phone.TextLength < 11 || textBox_phone.Text == "+7 XXX XXX XX XX")
            {
                MessageBox.Show("1.Введите имя\r\n" +
                    "2.Введите существующий адрес эл.почты\r\n" +
                    "3.Введите номер телефона", "Несоответствие форме создания записи\r\n");
            }
            else if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Клиент:  " + textBox_name.Text + "\r\n" +
                   "Услуга:   " + label_service.Text + "\r\n" +
                   "Мастер:  " + label_staff_name.Text + "\r\n" +
                   "Стоимость услуги:  " + label_cost.Text + "\r\n\n" +
                   "Время записи:  " + label_date.Text + " " + label_time.Text + "\r\n\n" +
                   "\t\tЗапись успешно добавлена.\t\t", "Добавление записи...");


                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlConnection customer_to_service_connection = new MySqlConnection(myConnectionString);
                MySqlCommand command_max = new MySqlCommand("select max(idcustomers) from customers", customer_to_service_connection);
                customer_to_service_connection.Open();


                customers_count = command_max.ExecuteScalar().ToString();
                id_customer = Convert.ToInt32(customers_count);

                customer_to_service_connection.Close();


                MySqlCommand cmd_2 = new MySqlCommand("insert into customers_to_staff(id_staff,id_customer,id_service,appointment_time) values (@id_staff,@id_customer,@id_service,@appointment_time)", db.getConnection());
                cmd_2.Parameters.Add("@id_staff", MySqlDbType.VarChar).Value = staff_1.id_staff;
                cmd_2.Parameters.Add("@id_customer", MySqlDbType.VarChar).Value = id_customer;
                cmd_2.Parameters.Add("@id_service", MySqlDbType.VarChar).Value = services_1.id_service;
                cmd_2.Parameters.Add("@appointment_time", MySqlDbType.VarChar).Value = creating_service.date_string + " " + creating_service.time;

                adapter.SelectCommand = cmd_2;
                adapter.Fill(table);

                db.closeConnection();

                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    if (Application.OpenForms[i].Name != "appointment")
                    {
                        Application.OpenForms[i].Close();  
                    }
                }

            }
            else
            {
                MessageBox.Show("Произошла ошибка при добавлении сотрудника.", "Ошибка при добавлении...");
            }
        }

        private void textBox_phone_Enter(object sender, EventArgs e)
        {
            if (textBox_phone.Text == "+7 XXX XXX XX XX")
                textBox_phone.Text = "";
        }

        private void textBox_phone_Leave(object sender, EventArgs e)
        {
            if (textBox_phone.Text == "")
            {
                textBox_phone.Text = "+7 XXX XXX XX XX";
                textBox_phone.ForeColor = Color.DimGray;
            }
        }

        private void textBox_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox_phone_MouseEnter(object sender, EventArgs e)
        {
            textBox_phone.ForeColor = Color.DarkSlateGray;
        }

        private void textBox_phone_MouseLeave(object sender, EventArgs e)
        {
            if (textBox_phone.Text == "" || textBox_phone.Text == "+7 XXX XXX XX XX")
                textBox_phone.ForeColor = Color.Gray;
        }

        private void textBox_email_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && !Char.IsLetter(number) && number != 45 && number != 46 && number != 64)
            {
                e.Handled = true;
            }
        }

        private void textBox_phone_MouseHover(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(textBox_phone, "Минимальная длина номера телефона 11 цифр");
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
