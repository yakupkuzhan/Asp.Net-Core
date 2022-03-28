
using CoreAppFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks; 


namespace CoreAppFood.ViewComponents
{
    public class FoodListByCategory : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            FoodRepository foodRepository = new FoodRepository();
            var foodList = foodRepository.Lst(x => x.CategoryId == id);
            return View(foodList);
        }
    }
}
