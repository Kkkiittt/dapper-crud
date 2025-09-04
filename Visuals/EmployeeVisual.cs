using CompanyCrud.Application.Interfaces.Services;

namespace CompanyCrud.Cons.Visuals;

public class EmployeeVisual
{
	private readonly IEmployeeService _serv;

	public EmployeeVisual(IEmployeeService serv)
	{
		_serv = serv;
	}

	public void Show()
	{
		Console.Clear();
		Console.WriteLine("1. Add\n2. Update\n3. Remove\n4. Get\n5. GetAll");
		var key = Console.ReadKey(true).Key;
		switch(key)
		{
			case ConsoleKey.D1:
				Add();
				Console.ReadKey(true);
				break;
			case ConsoleKey.D2:
				Update();
				Console.ReadKey(true);
				break;
			case ConsoleKey.D3:
				Remove();
				Console.ReadKey(true);
				break;
			case ConsoleKey.D4:
				Get();
				Console.ReadKey(true);
				break;
			case ConsoleKey.D5:
				GetAll();
				Console.ReadKey(true);
				break;
		}
	}

	public void Update()
	{
		Console.WriteLine("Enter id:");
		var id = int.Parse(Console.ReadLine()!);
		Console.WriteLine("Enter name:");
		var name = Console.ReadLine()!;
		Console.WriteLine("Enter branch id:");
		var branchId = int.Parse(Console.ReadLine()!);
		Console.WriteLine("Enter salary:");
		var salary = float.Parse(Console.ReadLine()!);
		_serv.Update(id, name, branchId, salary);
	}

	public void Add()
	{
		Console.WriteLine("Enter name:");
		var name = Console.ReadLine()!;
		Console.WriteLine("Enter branch id:");
		var branchId = int.Parse(Console.ReadLine()!);
		Console.WriteLine("Enter salary:");
		var salary = float.Parse(Console.ReadLine()!);
		Console.WriteLine(_serv.Add(name, branchId, salary));
	}

	public void Remove()
	{
		Console.WriteLine("Enter id:");
		var id = int.Parse(Console.ReadLine()!);
		Console.WriteLine(_serv.Remove(id));
	}

	public void Get()
	{
		Console.WriteLine("Enter id:");
		var id = int.Parse(Console.ReadLine()!);
		var employee = _serv.Get(id);
		Console.WriteLine(employee);
	}

	public void GetAll()
	{
		foreach(var employee in _serv.GetAll())
			Console.WriteLine(employee);
	}
}
