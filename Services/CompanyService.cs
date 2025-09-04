using CompanyCrud.Entities;

using Dapper;

namespace CompanyCrud.Services;

internal class CompanyService
{
	private readonly DbContext _db;

	public CompanyService(DbContext db)
	{
		_db = db;
	}

	public int Add(string name)
	{
		using var conn = _db.CreateConnection();
		string sql = "INSERT INTO Companies (Name) VALUES (@Name)	RETURNING Id";
		return conn.ExecuteScalar<int>(sql, new { Name = name });
	}

	public Company Get(int id)
	{
		using var conn = _db.CreateConnection();
		string sql = "SELECT id, name FROM Companies WHERE Id = @Id";
		return conn.QueryFirst<Company>(sql, new { Id = id });
	}

	public List<Company> GetAll()
	{
		using var conn = _db.CreateConnection();
		string sql = "SELECT id,name FROM Companies";
		return conn.Query<Company>(sql).ToList();
	}

	public bool Remove(int id)
	{
		using var conn = _db.CreateConnection();
		string sql = "DELETE FROM Companies WHERE Id = @Id";
		return conn.Execute(sql, new { Id = id }) > 0;
	}

	public void Update(int id, string name)
	{
		using var conn = _db.CreateConnection();
		string sql = "UPDATE Companies SET Name = @Name WHERE Id = @Id";
		conn.Execute(sql, new { Id = id, Name = name });
	}
}
