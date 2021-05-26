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
    public class TestsController : ControllerBase
    {
        ApplicationContext db;
        public TestsController(ApplicationContext context)
        {
            db = context;
            if (!db.Tests.Any())
            {

                Question q1 = new Question { Name = "Вы бабочка?", Option1 = "Естественно", Option2 = "Не естественно", Answer = 1 };
                Question q2 = new Question { Name = "Вы девочка?", Option1 = "Конечно", Option2 = "Не конечно", Answer = 1 };
                Question q3 = new Question { Name = "Вы ходили?", Option1 = "Конечно", Option2 = "Не конечно", Answer = 1 };
                Question q4 = new Question { Name = "Вы человек?", Option1 = "Естественно", Option2 = "Не естественно", Answer = 1 };
                db.Questions.AddRange(new List<Question> { q1, q2, q3, q4 });
                db.SaveChanges();
                
                Test t1 = new Test { Name = "Test №1", Description = "По прохождений этого теста вы узнаете кто вы из Винкс" };
                t1.Questions.Add(q1);
                t1.Questions.Add(q2);
                Test t2 = new Test { Name = "Test №2", Description = "Кем ты был в прошлой жизни" };
                t2.Questions.Add(q3);
                t2.Questions.Add(q4);
                db.Tests.Add(t1);
                db.Tests.Add(t2);
                db.SaveChanges();
            }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Test>>> Get()
        {
            var list =  await db.Tests.ToListAsync();
            list.Reverse();
            return list;
        }
    }
}