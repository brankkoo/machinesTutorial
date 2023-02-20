using System.ComponentModel;

namespace MachinesTutorial.Model
{
    public class Video 
    {
        public int VideoId { get; set; }
        public Step? Step { get; set; }
        public int? StepId { get; set; }
        public string? Source
        {
            get; set;
        }


        
    }
}