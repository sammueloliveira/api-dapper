using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data;

namespace Dapper.Infra.Data
{
    public class Contexto : IDisposable
    {
        public IDbConnection Connection { get; }

        public Contexto(IConfiguration configuration)
        {
            Connection = new MySqlConnection(configuration.GetConnectionString("Connection"));
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection != null)
            {
                Connection.Close(); 
                Connection.Dispose(); 
            }
        }
    }
}
