using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API1enNET8.Models;

public partial class Person
{
    public int IdPerson { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Tel { get; set; }
    [JsonIgnore]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
