using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API1enNET8.Models;
using Microsoft.AspNetCore.Cors;

namespace API1enNET8.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly EmployeeContext _dbContext;
        public DepartmentController(EmployeeContext context)
        {
            _dbContext = context;
        }

        //CRUD
        //Create
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Department entity)
        {
            try
            {
                _dbContext.Departments.Add(entity);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok, Saved" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Error" });
            }
        }
        //Read
        [HttpGet]
        [Route("ReadList")]
        public ActionResult ReadList()
        {
            List<Department> resultList = new List<Department>();
            try
            {
                resultList = _dbContext.Departments.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = resultList });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.ToString() });
            }
        }

        [HttpGet]
        [Route("Read/{idDepartment:int}")]
        public ActionResult Read(int idDepartment)
        {
            Department? oDepartment = new Department();
            try
            {
                oDepartment = _dbContext.Departments.Find(idDepartment);

                if (oDepartment == null)
                {
                    return BadRequest("Not found");
                }
                oDepartment = _dbContext.Departments.Where(p => p.IdDepartment == idDepartment).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = oDepartment });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.ToString() });
            }
        }
        //Update
        [HttpPut]
        [Route("Update")]
        public ActionResult Update([FromBody] Department entity)
        {
            Department? oDepartment = new Department();
            try
            {
                oDepartment = _dbContext.Departments.Find(entity.IdDepartment);

                if (oDepartment == null)
                {
                    return BadRequest("Not found");
                }
                oDepartment.Description = entity.Description;

                _dbContext.Departments.Update(oDepartment);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Is updated" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.ToString() });
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete([FromBody] Department entity)
        {
            Department? oDepartment = new Department();
            try
            {
                oDepartment = _dbContext.Departments.Find(entity.IdDepartment);

                if (oDepartment == null)
                {
                    return BadRequest("Not found");
                }
                _dbContext.Departments.Remove(oDepartment);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Deleted" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.ToString() });
            }
        }
    }
}
