using School_API.Data;

namespace School_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private School_DbContext DbContext_V;
        public StudentsController(School_DbContext DbContext_V)
        {
            this.DbContext_V = DbContext_V;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var x = DbContext_V.Students.ToList();
            return Ok(x);
        }

    }
}
