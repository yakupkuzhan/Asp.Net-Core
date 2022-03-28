using CoreAppFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreAppFood.ViewComponents
{
    public class GetFoodList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FoodRepository foodRepository = new FoodRepository();
            var foodList = foodRepository.TList();
            return View(foodList);
        }
    }
}
