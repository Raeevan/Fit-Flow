using System.ComponentModel.DataAnnotations;

namespace FitFlow.Models.Entities
{
    public class Class
    {
        [Key] public int ClassID { get; set; }

        public string ClassName { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int InstructorID { get; set; }
    }
}
