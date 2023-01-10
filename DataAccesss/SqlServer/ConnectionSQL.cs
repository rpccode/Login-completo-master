using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccesss
{
    public abstract class ConnectionSQL
    {
        private readonly string connectionString;

        public ConnectionSQL()
        {
            connectionString = "Server=(local);Database=MyCompany; Trusted_Connection= true";

        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
