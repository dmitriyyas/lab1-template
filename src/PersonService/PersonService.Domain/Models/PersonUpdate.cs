using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.Domain.Models;

public class PersonUpdate(string name,
    int? age,
    string? address,
    string? work)
{
    public string Name { get; set; } = name;
    public int? Age { get; set; } = age;
    public string? Address { get; set; } = address;
    public string? Work { get; set; } = work;
}
