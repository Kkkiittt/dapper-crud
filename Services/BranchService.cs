using CompanyCrud.Entities;

using Dapper;

namespace CompanyCrud.Services;

internal class BranchService
{
	private readonly DbContext _db;

	public BranchService(DbContext db)
	{
		_db = db;
	}

	public int Add(string name, int departmentId)
	{
		using var conn = _db.CreateConnection();
		string sql = "INSERT INTO Branches (Name, Department_Id) VALUES (@Name, @DepartmentId) RETURNING Id";
		return conn.ExecuteScalar<int>(sql, new { Name = name, DepartmentId = departmentId });
	}

	public Branch Get(int id)
	{
		using var conn = _db.CreateConnection();
		string sql = "SELECT id,name,department_id AS departmentId FROM Branches WHERE Id = @Id";
		return conn.QueryFirst<Branch>(sql, new { Id = id });
	}

	public List<Branch> GetAll()
	{
		using var conn = _db.CreateConnection();
		string sql = "SELECT id,name,department_id AS departmentId FROM Branches";
		return conn.Query<Branch>(sql).ToList();
	}

	public void Update(int id, string name, int departmentId)
	{
		using var conn = _db.CreateConnection();
		string sql = "UPDATE Branches SET Name = @Name, Department_Id = @DepartmentId WHERE Id = @Id";
		conn.Execute(sql, new { Id = id, Name = name, DepartmentId = departmentId });
	}

	public bool Remove(int id)
	{
		using var conn = _db.CreateConnection();
		string sql = "DELETE FROM Branches WHERE Id = @Id";
		return conn.Execute(sql, new { Id = id }) > 0;
	}
}
