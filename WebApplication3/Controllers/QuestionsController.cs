using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebAPIApp.Models;
using System.Threading.Tasks;

namespace WebAPIApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        ApplicationContext db;
        public QuestionsController(ApplicationContext context)
        {
            db = context;
            if (!db.Questions.Any())
            {
                db.Questions.Add(new Question { Name = "Вы бабочка?", Option1 = "Естественно", Option2 = "Не естественно", Answer = 1 });
                db.Questions.Add(new Question { Name = "Вы девочка?", Option1 = "Конечно", Option2 = "Не конечно", Answer = 1 });
                db.Questions.Add(new Question { Name = "Вы ходили?", Option1 = "Конечно", Option2 = "Не конечно", Answer = 1 });
                db.Questions.Add(new Question { Name = "Вы человек?", Option1 = "Естественно", Option2 = "Не естественно", Answer = 1 });
                db.SaveChanges();
            }
        }

        


        // GET api/questions/"Название чата"
        [HttpGet("{Name}")]
        public async Task<ActionResult<IEnumerable<Question>>> Get(string name)
        {

            Test test = await db.Tests.Include(t => t.Questions).FirstOrDefaultAsync(k => k.Name == name);

            if (test != null)
            {
                return await db.Questions.Include(t => t.Tests).Where(c => c.Tests.Contains(test)).ToListAsync();
            }
            return NotFound();
        }
    }
}