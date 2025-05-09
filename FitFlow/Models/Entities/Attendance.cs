using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitFlow.Models.Entities
{
    public class Attendance
    {
        [Key]
        public int AttendanceID { get; set; }

        [ForeignKey("ClassID")]
        public int classID { get; set; }
        [ForeignKey("PersonID")]
        public int PersonID { get; set; }
        public DateTime AttendanceDate { get; set; }
    }
}
