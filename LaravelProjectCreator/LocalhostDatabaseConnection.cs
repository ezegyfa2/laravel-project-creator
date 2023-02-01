using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaravelProjectCreator
{
    public class LocalhostDatabaseConnection : DatabaseConnection
    {
        public LocalhostDatabaseConnection(string databaseName): base(databaseName, "127.0.0.1", "root", "")
        {
        }
    }
}
