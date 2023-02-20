using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinesTutorial.Model
{
    public class Machine 
    {
       
        public int Id { get; set; }
        public int StepId { get; set; }
        public string? Name
        {
            get; set;
        }

        public int? Progress
        { get; set; }
        
        public string? PhotoSource { get; set; }

        public string? Description { get; set; }
        public List<Step>? Steps
        {
            get; set;

        }


     
    }
}
