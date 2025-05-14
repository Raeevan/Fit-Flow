using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitFlow.Models.Entities
{
    public class UserRole
    {
        [Key]
        public int UserRoleID { get; set; }

        [Required]
        [ForeignKey("Person")]
        public int PersonID { get; set; }
        public Person? Person { get; set; }

        [Required]
        [ForeignKey("Role")]
        public int RoleID { get; set; }
        public Role? Role { get; set; }

        [Required]
        public DateTime AssignedAt { get; set; } = DateTime.Now.Date;

       

        
    }
}
