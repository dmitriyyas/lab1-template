using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonService.Domain.Exceptions;

public class PersonNotFoundException : Exception
{
    public PersonNotFoundException() { }
    public PersonNotFoundException(string message) : base(message) { }
}
