using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beauty_salon
{
    internal class Database
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=1337;database=beauty_salon");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed) //Открываем соединение
                connection.Open();
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open) //Закрываем соединение
                connection.Close();
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
