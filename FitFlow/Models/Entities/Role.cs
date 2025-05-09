using System.ComponentModel.DataAnnotations;

namespace FitFlow.Models.Entities
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

    }
}
