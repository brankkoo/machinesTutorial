using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinesTutorial.Model.Dto
{
    public class ResultDto
    {
        public List<QuizQuestion> QuizQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public List<string> QuizQuestionsResults { get; set; }


    }
}
