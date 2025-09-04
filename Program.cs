using CompanyCrud.Cons.Visuals;
using CompanyCrud.Infrastructure;
using CompanyCrud.Infrastructure.Services;

namespace CompanyCrud.Cons;
internal class Program
{
	private readonly DbContext _db;
	private readonly CompanyVisual _company;
	private readonly DepartmentVisual _department;
	private readonly BranchVisual _branch;
	private readonly EmployeeVisual _employee;
	static void Main(string[] args)
	{
		Program prg = new Program();

		prg.Work();
	}
	public Program()
	{
		_db = new();
		_company = new(new CompanyService(_db));
		_department = new(new DepartmentService(_db));
		_branch = new(new BranchService(_db));
		_employee = new(new EmployeeService(_db));
	}
	public void Work()
	{
		bool flag = true;
		while(flag)
		{
			Console.Clear();
			Console.WriteLine("1. Company\n2. Department\n3. Branch\n4. Employee\n0. Exit");
			var key = Console.ReadKey(true).Key;
			switch(key)
			{
				case ConsoleKey.D1:
					SafelyDo(_company.Show);
					break;
				case ConsoleKey.D2:
					SafelyDo(_department.Show);
					break;
				case ConsoleKey.D3:
					SafelyDo(_branch.Show);
					break;
				case ConsoleKey.D4:
					SafelyDo(_employee.Show);
					break;
				case ConsoleKey.D0:
					flag = false;
					break;
			}
		}
	}
	private void SafelyDo(Action act)
	{
		try
		{
			act();
		}
		catch(Exception ex)
		{
			Console.WriteLine(ex.ToString());
			Console.ReadLine();
		}
	}
}
