using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API1enNET8.Models;

public partial class JobTitle
{
    public int IdJobTitle { get; set; }

    public string Description { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
