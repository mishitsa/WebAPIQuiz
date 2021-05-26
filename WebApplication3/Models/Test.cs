using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebAPIApp.Models
{
    public class Test
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } //Название теста
        #nullable enable
        public string? Description { get; set; } // Описание теста

        #nullable disable
        //public virtual ICollection<QuestionTest> QuestionTests { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        public Test()
        {
            Questions = new List<Question>();
        }
    }
}
