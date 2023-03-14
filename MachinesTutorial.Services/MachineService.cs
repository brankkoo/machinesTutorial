using MachinesTutorial.Model;
using MachinesTutorial.Model.Context;
using MachinesTutorial.Model.Dto;
using MachinesTutorial.Model.Extenstions;
using MachinesTutorial.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinesTutorial.Services
{
    public class MachineService : IMachineService
    {
        private readonly MachineContext _context;
        public MachineService(IMachineContext context)
        {
            _context= context as MachineContext;
        }

        //then include
        public List<Machine> GetMachines()
        {
            var machines = _context.Machines
                .Include(m => m.QuizQuestions)
                .ThenInclude(e => e.QuizChoices)
                .Include(m => m.Steps)
                .ThenInclude(e => e.Photos)
                .ToList();
            return machines;
        }

        public Step GetStepById(int id, int machineId)
        {
            var machines = GetMachines();
            if (machines != null && machines.Select(s => s.Steps) != null)
                return machines.SelectMany(s => s.Steps).FirstOrDefault(s => s.OrderNum == id && s.MachineId == machineId);
            else
                throw new Exception("Database is broken");
        }

        public string GetMachineName(int id)
        {
            var machines = _context.Machines.Find(id);
            if (machines != null)
                return machines.Name;
            else
                throw new Exception("Database is broken");
        }

        public void UpdateMachine(Machine machine)
        {
            _context.Machines.Update(machine);
            _context.SaveChanges();        
                
        }

        public ResultDto QuizResultCalcualtion(List<QuizQuestion> quizQuestions)
        {
            List<string> results= new List<string>();
            int totalQuestions = quizQuestions.Count;
            int correctAnswers = 0;
            foreach (var question in quizQuestions)
            {
                if (question.IsCorrectAnswer())
                {
                    results.Add("Correct");
                    correctAnswers++;
                }
                else
                {
                    results.Add("Incorrect");
                }
                
            }
            
           
            
            var machine = _context.Machines.Find(quizQuestions.First().MachineId);
             machine.QuizGrade = correctAnswers;
            _context.Machines.Update(machine);
            _context.SaveChanges();

            var result = new ResultDto
            {
                QuizQuestions = quizQuestions,
                CorrectAnswers = correctAnswers,
                QuizQuestionsResults = results
            };

            return result;
        }

    }
}
