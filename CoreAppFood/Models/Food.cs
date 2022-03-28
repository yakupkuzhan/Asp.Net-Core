

using System.ComponentModel.DataAnnotations;

namespace CoreAppFood.Models
{
    public class Food
    {
        public int FoodId { get; set; }

        //[Required(ErrorMessage = "Food name can not empty..!")]
        public string Name { get; set; }              
        public string Desc { get; set; }
        
        //[Required(ErrorMessage ="Product price can not empty..!")]
        public double Price { get; set; }              
        public string ImageUrl { get; set; }

        //[Required(ErrorMessage = "Stok quantity can not empty..!")]
        public int Stock { get; set; }


        public int CategoryId { get; set; }
        public  virtual Category Category { get; set; }

    }
}
