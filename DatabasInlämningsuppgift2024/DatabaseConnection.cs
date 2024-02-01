using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasInlämningsuppgift2024
{
    public class DatabaseConnection
    {
        string server = "localhost";
        string database = "databasInlämning2024";
        string username = "root";
        string password = "Raashido99";

        string connectionString = "";
        MySqlConnection connection;

        public DatabaseConnection()
        {
            connectionString = "SERVER=" + server + ";" +
                               "DATABASE=" + database + ";" +
                               "UID=" + username + ";" +
                               "PASSWORD=" + password + ";";
           
            connection = new MySqlConnection(connectionString);
        }


    }
}
