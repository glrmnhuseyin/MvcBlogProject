using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
        public IActionResult Index()
        {
            var categoryvalues=categoryManager.GetList();
            return View(categoryvalues);
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult AddCategory(Category category)
        {
            CategoryValidator categoryvalidator=new CategoryValidator();
            ValidationResult results = categoryvalidator.Validate(category);
            if (results.IsValid)
            {
                categoryManager.CategoryAdd(category);
                return RedirectToAction("Index");
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
