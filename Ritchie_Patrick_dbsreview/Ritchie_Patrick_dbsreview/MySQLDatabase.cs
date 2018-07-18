using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;

namespace Ritchie_Patrick_dbsreview
{
    class MySQLDatabase
    {
        private MySqlConnection _conn;

        public MySQLDatabase()
        {
            _conn = new MySqlConnection();
        }

        public void Connect(string userId, string userPassword, string dbName)
        {
            BuildConnString(userId, userPassword, dbName);
            try
            {
                _conn.Open();

                Console.WriteLine("Connected successfully!");
            }
            catch (MySqlException e)
            {
                string msg = "";
                switch (e.Number)
                {
                    case 0:
                        {
                            msg = e.ToString();
                        }
                        break;
                    case 1042:
                        {
                            msg = $"Can't resolve host address.\n{_conn.ConnectionString}";
                        }
                        break;
                    case 1045:
                        {
                            msg = "Invalid username/password.";
                        }
                        break;

                }
                Console.WriteLine(msg);
            }
        }

        private void BuildConnString(string user, string password, string dbName)
        {
            StringBuilder connString = new StringBuilder();
            connString.Append("Server=");
            connString.Append($"{ReadIpFromFile()};");
            connString.Append($"uid={user};");
            connString.Append($"pwd={password};");
            connString.Append($"database={dbName};");
            connString.Append($"port=8889;");
            connString.Append("sslmode=none;");

           // Console.WriteLine($"Connection string: {connString.ToString()}");
            _conn.ConnectionString = connString.ToString();

        }
        private string ReadIpFromFile()
        {
            string serverIp = "Falied to load IP from file";
            try
            {
                using (StreamReader sr = new StreamReader("C:/VFW/connect.txt"))
                {
                    serverIp = sr.ReadLine();
                }

            }
            catch (Exception)
            {
                throw;
            }
            return serverIp;
        }
        public void Query(string query, DataTable data)
        {
            MySqlDataAdapter adr = new MySqlDataAdapter(query, _conn);
            adr.SelectCommand.CommandType = CommandType.Text;
            adr.Fill(data);

        }
        public void CloseConnection()
        {
            _conn.Close();
        }
    }
}
