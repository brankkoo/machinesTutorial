using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinesTutorial.Model
{
    public class QuizChoice
    {
        public int Id { get; set; }
        public string? Choice { get; set; }
        public int QuizQuestionId { get; set; }
        public QuizQuestion QuizQuestion { get; set; }
    }
}
