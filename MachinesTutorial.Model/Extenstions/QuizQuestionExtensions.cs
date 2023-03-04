using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinesTutorial.Model.Extenstions
{
    public static class QuizQuestionExtensions
    {
        public static bool IsCorrectAnswer(this QuizQuestion question)
        {
            return question.AnswerId.Value == question.CurrentChoice.Value;
        }
    }
}
