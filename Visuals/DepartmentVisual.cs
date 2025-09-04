using CompanyCrud.Application.Interfaces.Services;
using CompanyCrud.Infrastructure;
using CompanyCrud.Infrastructure.Services;

namespace CompanyCrud.Cons.Visuals;

public class DepartmentVisual
{
	private readonly IDepartmentService _serv;

	public DepartmentVisual(IDepartmentService serv)
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

	public void Add()
	{
		Console.WriteLine("Enter name:");
		var name = Console.ReadLine()!;
		Console.WriteLine("Enter company id:");
		var companyId = int.Parse(Console.ReadLine()!);
		Console.WriteLine(_serv.Add(name, companyId));
	}

	public void Get()
	{
		Console.WriteLine("Enter id:");
		var id = int.Parse(Console.ReadLine()!);
		var department = _serv.Get(id);
		Console.WriteLine(department);
	}

	public void GetAll()
	{
		foreach(var department in _serv.GetAll())
			Console.WriteLine(department);
	}

	public void Update()
	{
		Console.WriteLine("Enter id:");
		var id = int.Parse(Console.ReadLine()!);
		Console.WriteLine("Enter name:");
		var name = Console.ReadLine()!;
		Console.WriteLine("Enter company id:");
		var companyId = int.Parse(Console.ReadLine()!);
		_serv.Update(id, name, companyId);
	}

	public void Remove()
	{
		Console.WriteLine("Enter id:");
		var id = int.Parse(Console.ReadLine()!);
		Console.WriteLine(_serv.Remove(id));
	}
}
