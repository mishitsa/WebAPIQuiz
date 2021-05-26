using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebAPIApp.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } //Название вопроса
        [Required]
        public string Option1 { get; set; } //Вопрос1
        [Required]
        public string Option2 { get; set; } //Вопрос2
        [Required]
        public int Answer { get; set; } //Ответ


        //public virtual ICollection<QuestionTest> QuestionTests { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
        public Question()
        {
            Tests = new List<Test>();
        }
    }
}