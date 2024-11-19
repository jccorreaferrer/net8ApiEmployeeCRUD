using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API1enNET8.Models;
using Microsoft.AspNetCore.Cors;

namespace API1enNET8.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitleController : ControllerBase
    {
        private readonly EmployeeContext _dbContext;
        public JobTitleController(EmployeeContext context)
        {
                this._dbContext = context;
        }
        //CRUD
        //Create
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] JobTitle entity)
        {
            try
            {
                _dbContext.JobTitles.Add(entity);
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
            List<JobTitle> resultList = new List<JobTitle>();
            try
            {
                resultList = _dbContext.JobTitles.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = resultList });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.ToString() });
            }
        }

        [HttpGet]
        [Route("Read/{idJobTitle:int}")]
        public ActionResult Read(int idJobTitle)
        {
            JobTitle? oJobTitle = new JobTitle();
            try
            {
                oJobTitle = _dbContext.JobTitles.Find(idJobTitle);

                if (oJobTitle == null)
                {
                    return BadRequest("Not found");
                }
                oJobTitle = _dbContext.JobTitles.Where(p => p.IdJobTitle == idJobTitle).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = oJobTitle });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.ToString() });
            }
        }
        //Update
        [HttpPut]
        [Route("Update")]
        public ActionResult Update([FromBody] JobTitle entity)
        {
            JobTitle? oJobTitle = new JobTitle();
            try
            {
                oJobTitle = _dbContext.JobTitles.Find(entity.IdJobTitle);

                if (oJobTitle == null)
                {
                    return BadRequest("Not found");
                }
                oJobTitle.Description = entity.Description;

                _dbContext.JobTitles.Update(oJobTitle);
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
        public ActionResult Delete([FromBody] JobTitle entity)
        {
            JobTitle? oJobTitle = new JobTitle();
            try
            {
                oJobTitle = _dbContext.JobTitles.Find(entity.IdJobTitle);

                if (oJobTitle == null)
                {
                    return BadRequest("Not found");
                }
                _dbContext.JobTitles.Remove(oJobTitle);
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
