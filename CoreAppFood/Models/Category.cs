

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreAppFood.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category name can not empty..!")]
        //[StringLength(20, ErrorMessage = "Please enter a maximum of 20 characters")]
        public string CategoryName { get; set; }    
        public string CategoryDesc { get; set; }
        public bool IsDeleted { get; set; }

        public List<Food> Foods { get; set; }
    }
}
