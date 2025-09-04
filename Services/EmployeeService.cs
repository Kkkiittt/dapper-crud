using CompanyCrud.Entities;

using Dapper;

namespace CompanyCrud.Services;

internal class EmployeeService
{
	private readonly DbContext _db;

	public EmployeeService(DbContext db)
	{
		_db = db;
	}

	public int Add(string name, int branchId, float salary)
	{
		using var conn = _db.CreateConnection();
		string sql = "INSERT INTO Employees (Name, Branch_Id, Salary) VALUES (@Name, @BranchId, @Salary) RETURNING Id";
		return conn.ExecuteScalar<int>(sql, new { Name = name, BranchId = branchId, Salary = salary });
	}

	public Employee Get(int id)
	{
		using var conn = _db.CreateConnection();
		string sql = "SELECT id,name,branch_id AS branchId,salary FROM Employees WHERE Id = @Id";
		return conn.QueryFirst<Employee>(sql, new { Id = id });
	}

	public List<Employee> GetAll()
	{
		using var conn = _db.CreateConnection();
		string sql = "SELECT id,name,branch_id AS branchId,salary FROM Employees";
		return conn.Query<Employee>(sql).ToList();
	}

	public void Update(int id, string name, int branchId, float salary)
	{
		using var conn = _db.CreateConnection();
		string sql = "UPDATE Employees SET Name = @Name, Branch_Id = @BranchId, Salary = @Salary WHERE Id = @Id";
		conn.Execute(sql, new { Id = id, Name = name, BranchId = branchId, Salary = salary });
	}

	public bool Remove(int id)
	{
		using var conn = _db.CreateConnection();
		string sql = "DELETE FROM Employees WHERE Id = @Id";
		return conn.Execute(sql, new { Id = id }) > 0;
	}
}
