using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitFlow.Models.Entities
{
    public class Membership
    {
        [Key]
        public int MembershipID { get; set; }

        

        [Required(ErrorMessage = "Please select a membership type")]
        [Display(Name = "Membership Type")]
        [StringLength(50)]
        public string MembershipType { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Now.Date;

        [Required(ErrorMessage = "End date is required")]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } = DateTime.Now.Date.AddMonths(1);

        [Required(ErrorMessage = "Fee amount is required")]
        [Display(Name = "Fee")]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, 100000, ErrorMessage = "Fee must be between 0 and 100,000")]
        public decimal Fee { get; set; }

        [ForeignKey("Person")]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please select a Name")]
        public int? PersonID { get; set; }  
        public Person? Person { get; set; }
    }
}
