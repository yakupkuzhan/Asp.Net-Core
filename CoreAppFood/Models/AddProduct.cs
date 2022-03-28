using Microsoft.AspNetCore.Http;

namespace CoreAppFood.Models
{
    public class AddProduct
    {
        public string Name { get; set; }
        public string Desc { get; set; }

        //[Required(ErrorMessage ="Product price can not empty..!")]
        public double Price { get; set; }
        public IFormFile ImageUrl { get; set; }

        //[Required(ErrorMessage = "Stok quantity can not empty..!")]
        public int Stock { get; set; }


        public int CategoryId { get; set; }
    }
}
