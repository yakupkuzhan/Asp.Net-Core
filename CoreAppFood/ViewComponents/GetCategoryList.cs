
using CoreAppFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreAppFood.ViewComponents
{
    public class GetCategoryList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            var categoryList = categoryRepository.TList();
            return View(categoryList);
        }
    }
}
