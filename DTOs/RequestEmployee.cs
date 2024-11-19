using API1enNET8.Models;

namespace API1enNET8.DTOs
{
    public class RequestEmployee
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
}
