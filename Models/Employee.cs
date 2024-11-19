using System;
using System.Collections.Generic;


namespace API1enNET8.Models;

public partial class Employee
{
    public int IdEmployee { get; set; }

    public int IdPerson { get; set; }

    public int IdDepartment { get; set; }

    public int IdJobTitle { get; set; }

    public string? PersonalTitle { get; set; }

    public decimal? Salary { get; set; }
    
    public virtual Department ObjDepartment { get; set; } = null!;

    public virtual JobTitle ObjJobTitle { get; set; } = null!;

    public virtual Person ObjPerson { get; set; } = null!;
}
