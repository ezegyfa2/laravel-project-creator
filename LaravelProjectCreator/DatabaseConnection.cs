using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaravelProjectCreator
{
    public class DatabaseConnection
    {
        public string DatabaseName;
        public string Host;
        public string UserName;
        public string Password;
        public string Port;

        public DatabaseConnection(string databaseName, string host, string userName, string password, string port = "3306")
        {
            DatabaseName = databaseName;
            Host = host;
            UserName = userName;
            Password = password;
            Port = port;
        }
    }
}
