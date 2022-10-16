using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using testASP.Domain.Entities;
using testASP.Domain.Repositories;
using testASP.Service;

namespace testASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GoodsItemsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment webHostEnvironment;
        public GoodsItemsController(DataManager dataManager, IWebHostEnvironment webHostEnvironment)
        {
            this.dataManager = dataManager;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(dataManager.Categories.GetCategories(), "Id", "Name");

            var entity = id == default ? new GoodsItem() : dataManager.GoodsItems.GetGoodsItemById(id);

            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(GoodsItem model, IFormFileCollection images)
        {
            if (ModelState.IsValid)
            {
                bool isCreate = false;
                
                if (model.Id == default)
                {
                    isCreate = true;
                }

                int folder = dataManager.GoodsItems.SaveGoodsItem(model);

                if (isCreate)
                {
                    FolderOperations.CreateFolderForGoods(HttpContext, folder);
                }

                if (images != null)
                {
                    foreach (var image in images) // в отдельное действие?
                    {
                        var newImg = new GoodsImages()
                        {
                            ImgPath = Path.Combine("App_Data", model.Id.ToString(), image.FileName),
                            Goods = model
                        };

                        dataManager.GoodsItems.SaveGoodsImage(newImg);

                        using (var stream = new FileStream(HttpContext.Request.PathBase + "App_Data/" + model.Id.ToString() + "/" + image.FileName, FileMode.Create))
                        {
                            image.CopyTo(stream);
                        }

                    }
                }

                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutControllerPart());
            }
            return View(model);
        }

        [HttpPost] // на кнопку
        public IActionResult DeleteImage(GoodsItem model, int id)
        {
            dataManager.GoodsItems.DeleteGoodsImage(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            dataManager.GoodsItems.DeleteGoodsItem(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutControllerPart());
        }
    }
}
