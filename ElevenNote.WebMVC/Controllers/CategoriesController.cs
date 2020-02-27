using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.WebMVC.Controllers
{
    
    public class CategoriesController : Controller
    {
        CategoryService _categoryService = new CategoryService();

        // GET: Categories
        public ActionResult Index()
        {
            var model = _categoryService.GetCategories();
            return View(model);
        }
        //GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            if (_categoryService.CreateCategory(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Note could not be created.");
            return View(model);

        }
        //GET: Category/Detail
        public ActionResult Detail(int id)
        {
            
            var model = _categoryService.GetCategoryById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var detail = _categoryService.GetCategoryById(id);
            var model =
                new CategoryEdit
                {
                    CategoryID = detail.CategoryID,
                    CategoryName = detail.CategoryName,
                    
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            
            if (model.CategoryID != id)
            {
                ModelState.AddModelError("", "id Mismatch");
                return View(model);
            }

            if (_categoryService.EditCategory(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = _categoryService.GetCategoryById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");

        }
       
    }
}