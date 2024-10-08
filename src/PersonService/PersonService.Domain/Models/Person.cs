using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.Domain.Models;

public class Person(int id,
    string name,
    int? age,
    string? address,
    string? work)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public int? Age { get; set; } = age;
    public string? Address { get; set; } = address;
    public string? Work { get; set; } = work;
}
