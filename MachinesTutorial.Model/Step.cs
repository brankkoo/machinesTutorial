using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachinesTutorial.Model
{
    public class Step 
    {

        
        public int StepId { get; set; }
        
        public int MachineId { get; set; }
        public Machine? Machine { get; set; }
        public string? Title
        {
            get; set;
        }

        public string? Description
        {
            get; set;
        }

        public List<Photo>? Photos
        {
            get; set;
        }

        public List<Video>? Video
        {

            get; set;
        }

        public int? OrderNum { get; set; }



     
    }
}