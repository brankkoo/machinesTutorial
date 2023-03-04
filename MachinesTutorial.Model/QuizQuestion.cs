using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinesTutorial.Model
{
    public class QuizQuestion
    {
        public int Id { get; set; }
        public string? Question { get; set; }
        public int? AnswerId { get; set; }
        public int? CurrentChoice { get; set; }
        public int MachineId { get; set; }
        public List<QuizChoice>? QuizChoices { get; set; }
        public Machine Machine { get; set; }
        public int? OrderNum { get; set; }

    }
}
