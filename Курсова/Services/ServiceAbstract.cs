using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;

namespace Курсова.Services
{
    abstract class ServiceAbstract
    {
        protected MySqlConnection connection;
        protected MySqlCommand command;
        protected MySqlDataReader reader = null;
        protected string myConnectionString = "Database=chemistry_book;Data Source=localhost;User Id=root;Password=123456root";


        public ServiceAbstract() { }
        public ServiceAbstract(MySqlConnection conn, MySqlCommand comm) { connection = conn; command = comm; }

        public MySqlConnection getConnection() { return connection; }
        public MySqlCommand getCommand() { return command; }
        public void setConnection(MySqlConnection conn) { connection = conn; }
        public void setCommand(MySqlCommand comm) { command = comm; }
        public void connect()
        {
            try
            {
                connection = new MySqlConnection(myConnectionString);
                Console.WriteLine("connected");
            }
            catch (MySqlException e)
            {
                Console.Write("Error:" + e.ToString());
            }
        }

        public void open() { connection.Open(); }
        public void close() { connection.Close(); }
    }
}
