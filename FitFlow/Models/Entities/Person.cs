using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitFlow.Models.Entities
{
    public class Person
    {

        [Key]
        public int PersonID { get; set; }

 
        [StringLength(255)]
        public string PasswordHash { get; set; }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime joinDate { get; set; }

        public bool Status { get; set; }

        // Navigation properties
        public virtual ICollection<UserRole> UserRoles { get; set; }
        
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
