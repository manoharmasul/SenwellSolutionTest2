using Microsoft.Data.SqlClient;
using System.Data;

namespace SenwellSolutionTest2.Context
{
    public class DapperContext
    {
        private readonly IConfiguration configuration;
        private readonly string ConnectionString;
        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.ConnectionString = configuration.GetConnectionString("SqlConnection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(ConnectionString);
    }
}
