using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectionObject
{
    public abstract class DbConnection
    {
        public string ConnectionString { get; }
        public TimeSpan Timeout { get; set; }

        public DbConnection(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Connection string cannot be null or empty.");

            ConnectionString = connectionString;
            Timeout = TimeSpan.FromSeconds(30); // Default timeout
        }

        public abstract void Open();
        public abstract void Close();
    }
}
