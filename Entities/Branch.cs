namespace CompanyCrud.Entities;

internal class Branch
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public int DepartmentId { get; set; }

	public override string ToString()
	{
		return $"Id: {Id}, Name: {Name}, DepartmentId: {DepartmentId}";
	}
}
