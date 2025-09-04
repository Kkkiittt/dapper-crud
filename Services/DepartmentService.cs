using CompanyCrud.Entities;

using Dapper;

namespace CompanyCrud.Services;

internal class DepartmentService
{
	private readonly DbContext _db;

	public DepartmentService(DbContext db)
	{
		_db = db;
	}

	public List<Department> GetAll()
	{
		using var conn = _db.CreateConnection();
		string sql = "SELECT id,name,company_id AS companyId FROM Departments";
		return conn.Query<Department>(sql).ToList();
	}

	public Department Get(int id)
	{
		using var conn = _db.CreateConnection();
		string sql = "SELECT id,name,company_id AS companyId FROM Departments WHERE Id = @Id";
		return conn.QueryFirst<Department>(sql, new { Id = id });
	}

	public bool Remove(int id)
	{
		using var conn = _db.CreateConnection();
		string sql = "DELETE FROM Departments WHERE Id = @Id";
		return conn.Execute(sql, new { Id = id }) > 0;
	}

	public void Update(int id, string name, int companyId)
	{
		using var conn = _db.CreateConnection();
		string sql = "UPDATE Departments SET Name = @Name, Company_Id = @CompanyId WHERE Id = @Id";
		conn.Execute(sql, new { Id = id, Name = name, CompanyId = companyId });
	}

	public int Add(string name, int companyId)
	{
		using var conn = _db.CreateConnection();
		string sql = "INSERT INTO Departments (Name, Company_Id) VALUES (@Name, @CompanyId) RETURNING Id";
		return conn.ExecuteScalar<int>(sql, new { Name = name, CompanyId = companyId });
	}
}
