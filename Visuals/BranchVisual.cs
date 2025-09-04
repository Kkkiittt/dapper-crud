using CompanyCrud.Services;

namespace CompanyCrud.Visuals;

internal class BranchVisual
{
	private readonly BranchService _serv;
	public BranchVisual(DbContext db) => _serv = new(db);

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
	public void GetAll()
	{
		foreach(var branch in _serv.GetAll())
			Console.WriteLine(branch);
	}

	public void Get()
	{
		Console.WriteLine("Enter id:");
		var id = int.Parse(Console.ReadLine()!);
		var branch = _serv.Get(id);
		Console.WriteLine(branch);
	}

	public void Remove()
	{
		Console.WriteLine("Enter id:");
		var id = int.Parse(Console.ReadLine()!);
		Console.WriteLine(_serv.Remove(id));
	}

	public void Update()
	{
		Console.WriteLine("Enter id:");
		var id = int.Parse(Console.ReadLine()!);
		Console.WriteLine("Enter name:");
		var name = Console.ReadLine()!;
		Console.WriteLine("Enter department id:");
		var departmentId = int.Parse(Console.ReadLine()!);
		_serv.Update(id, name, departmentId);
	}

	public void Add()
	{
		Console.WriteLine("Enter name:");
		var name = Console.ReadLine()!;
		Console.WriteLine("Enter department id:");
		var departmentId = int.Parse(Console.ReadLine()!);
		Console.WriteLine(_serv.Add(name, departmentId));
	}
}
