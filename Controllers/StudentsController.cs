using School_API.Data;
using School_API.Models.DTOs;

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
            // x = [x1,x2,x3] each of these x is a row in students table

            var y = new List<students_dtos>();
            // y = [y1,y2,y3] each of these y is a row in students_dtos table

            foreach (var i in x)
            { // i is representing each row in students table (x1,x2,x3)

                // need to add new row for each i row
                y.Add(new students_dtos
                {
                    Id = i.Id,
                    Name = i.Name,
                    Email = i.Email
                });
            }
            return Ok(y);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var x = DbContext_V.Students.Find(id);
            if (x == null)
            {
                return NotFound();
            }
            else
            { // we don't need to make for loop here , because the response here will just return one object in list
                //      so one object will be helpful 
                // also we don't need to make new list for this
                //      one object is enough
                var y = new students_dtos()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email
                };
                return Ok(y);
            }
                
        }

    }
}
