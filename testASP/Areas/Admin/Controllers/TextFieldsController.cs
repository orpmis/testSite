using Microsoft.AspNetCore.Mvc;
using testASP.Domain.Entities;
using testASP.Domain.Repositories;
using testASP.Service;

namespace testASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TextFieldsController : Controller
    {
        private readonly DataManager dataManager;

        public TextFieldsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Edit(string codeWord)
        {
            TextField entity = dataManager.TextFields.GetTextFieldByCodeWord(codeWord);

            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(TextField model)
        {
            if (ModelState.IsValid)
            {
                dataManager.TextFields.SaveTextField(model);

                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutControllerPart());
            }
            return View(model);
        }
    }
}
