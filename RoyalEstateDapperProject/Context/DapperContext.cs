using System.Data;
using System.Data.SqlClient;

namespace RoyalEstateDapperProject.Context
{
	public class DapperContext
	{
		private readonly IConfiguration _configuration;
		private readonly string _connectionString;

		public DapperContext(IConfiguration configuration)
		{
			_configuration = configuration;
			_connectionString = _configuration.GetConnectionString("DefaultConnection");
		}
		public IDbConnection SqlConnection() => new SqlConnection(_connectionString);
	}
}
