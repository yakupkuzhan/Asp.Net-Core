

using System.ComponentModel.DataAnnotations;

namespace CoreAppFood.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [StringLength(20)]
        public string AdminName { get; set; }
        [StringLength(20)]
        public string AdminPassword { get; set; } 
        [StringLength(1)]
        public string AdminRole { get; set; }
    }
}
