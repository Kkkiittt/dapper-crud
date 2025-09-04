namespace CompanyCrud.Entities;

internal class Department
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public int CompanyId { get; set; }

	public override string ToString()
	{
		return $"Id: {Id}, Name: {Name}, CompanyId: {CompanyId}";
	}
}
