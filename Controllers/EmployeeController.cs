using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
    using API1enNET8.Models;
    using Microsoft.AspNetCore.Cors;

namespace API1enNET8.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _dbContext;
        public EmployeeController(EmployeeContext context)
        {
            this._dbContext = context;
        }

        //CRUD  
        [HttpPost]
        [Route("Create")]
        public ActionResult Create([FromBody] Employee entity)
        {
            try
            {
                this._dbContext.Employees.Add(entity);
                this._dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se guardo" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.ToString() });
            }
        }

        [HttpGet]
        [Route("ReadList")]
        public ActionResult ReadList() { 
        List<Employee> resultList= new List<Employee>();
            try
            {
                resultList = this._dbContext.Employees.Include(p=> p.ObjDepartment).Include(p=> p.ObjJobTitle).Include(p=>p.ObjPerson).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = resultList });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.ToString()});
            }
        }

        [HttpGet]
        [Route("Read/{IdEmployee:int}")]
        public ActionResult Read(int idEmployee)
        {
            Employee oEmployee= new Employee();
            try
            {
                oEmployee = this._dbContext.Employees.Find(idEmployee);

                if (oEmployee == null)
                {
                    return BadRequest("Not found");
                }
                oEmployee = this._dbContext.Employees.Include(p => p.ObjDepartment).Include(p => p.ObjJobTitle).Include(p => p.ObjPerson).Where(p=> p.IdEmployee==idEmployee).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = oEmployee });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.ToString() });
            }
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult Update([FromBody] Employee entity)
        {
            Employee oEmployee = new Employee();
            try
            {
                oEmployee = this._dbContext.Employees.Find(entity.IdEmployee);

                if (oEmployee == null)
                {
                    return BadRequest("Not found");
                }
                /*
                 solo se actualiza lo que trae
                */

                this._dbContext.Employees.Update(oEmployee);
                this._dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Is updated" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.ToString() });
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete([FromBody] Employee entity)
        {
            Employee oEmployee = new Employee();
            try
            {
                oEmployee = this._dbContext.Employees.Find(entity.IdEmployee);

                if (oEmployee == null)
                {
                    return BadRequest("Not found");
                }
                this._dbContext.Employees.Remove(oEmployee);
                this._dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Is Deleted" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.ToString() });
            }
        }




    }
}
