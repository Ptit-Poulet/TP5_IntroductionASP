using Microsoft.AspNetCore.Mvc;
using TP5_IntroASP.Areas.Admin.ViewModels;
using TP5_IntroASP.DataAccessLayer;
using TP5_IntroASP.Models;

namespace TP5_IntroASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuchoicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            DAL dal = new DAL();

            List<Menuchoices> menuchoices = dal.MenuchoicesFact.GetAll(); 

            return View(menuchoices);
        }

        public IActionResult Create()
        {
            DAL dal = new DAL();

            Menuchoices menu = dal.MenuchoicesFact.CreateEmpty();

            return View("CreateEdit", menu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Menuchoices menu)
        {
            if (menu != null && menu.Description != null)
            {
                DAL dal = new DAL();

                Menuchoices? existe = dal.MenuchoicesFact.Get(menu.Id);
                if (existe != null)
                {
                    ModelState.AddModelError("Produit.Description", "Le choix de menu existe déjà.");
                }

                if (menu != null)
                {

                    return View("CreateEdit", menu);
                }

                dal.MenuchoicesFact.Save(menu);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id > 0)
            {
                DAL dal = new DAL();
                Menuchoices? menu = dal.MenuchoicesFact.Get(id);

                if (menu != null)
                {

                    return View("CreateEdit", menu);
                }
            }

            return View("AdminMessage", new AdminMessageVM("L'identifiant du produit est introuvable."));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Menuchoices menu)
        {
            if (menu != null && menu.Description != null)
            {
                DAL dal = new DAL();

                Menuchoices? existe = dal.MenuchoicesFact.GetByDescription(menu.Description);
                if (existe != null && existe.Id != menu.Id)
                {
                    ModelState.AddModelError("Produit.Description", "Le choix de menu existe déjà.");
                }

                if (!ModelState.IsValid)
                {

                    return View("CreateEdit", menu);
                }

                dal.MenuchoicesFact.Save(menu);
            }

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                DAL dal = new DAL();
                Menuchoices? menu = dal.MenuchoicesFact.Get(id);

                if (menu != null)
                {

                    return View(menu);
                }
            }

            return View("AdminMessage", new AdminMessageVM("L'identifiant du  est introuvable."));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if (id > 0)
            {
                new DAL().MenuchoicesFact.Delete(id);
            }

            return RedirectToAction("Index");
        }
    }
}
