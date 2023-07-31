using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace PharmacyCompany.Database
{
    internal class MsSqlDbInteraction : DbInteraction
    {
        public MsSqlDbInteraction(string connectionString) : base(connectionString) { }

        protected override DbConnection Connection()
        {
            return new SqlConnection(ConnectionString);
        }

        protected override DbCommand CreateCommand(string query, DbConnection connection)
        {
            if (connection is SqlConnection sqlConnection)
            {
                return new SqlCommand(query, sqlConnection);
            }

            return null;
        }
    }
}
