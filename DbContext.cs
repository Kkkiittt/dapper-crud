using System.Data;

using Npgsql;

namespace CompanyCrud;

internal class DbContext
{
	private readonly string _connectionString;

	public DbContext(string con = "host=localhost;port=5432;database=CompanyDb;user id=postgres;password=somepass")
	{
		_connectionString = con; //

	}

	public IDbConnection CreateConnection()
	{
		return new NpgsqlConnection(_connectionString);
	}
}
