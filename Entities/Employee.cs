namespace CompanyCrud.Entities;

internal class Employee
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public float Salary { get; set; }
	public int BranchId { get; set; }

	public override string ToString()
	{
		return $"Id: {Id}, Name: {Name}, Salary: {Salary}, BranchId: {BranchId}";
	}
}
