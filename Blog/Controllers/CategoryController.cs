using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class CategoryController : Controller
    {//Get:Category

        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetCategoryList()
        {
            var categoryvalues = categoryManager.GetList();
            return View(categoryvalues);
        }
        public IActionResult AddCategory()
        {
            Category category = new Category();
            return View(category);
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            //categoryManager.CategoryAddBll(category);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results=categoryValidator.Validate(category);
            if (results.IsValid)
            {
                categoryManager.CategoryAdd(category);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
 