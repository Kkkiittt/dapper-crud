using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCrud.Entities;

internal class Company
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;

	public override string ToString()
	{
		return $"Id: {Id}, Name: {Name}";
	}
}
