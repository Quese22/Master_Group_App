using MasterGroup.Models;
using MasterGroup.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterGroupWebApp.Controllers
{
    [Authorize]
    public class MasterGroupController : Controller
    {
        // GET: MasterGroup
        public ActionResult Index()
        {
            var service = CreateMasterGroupService();
            var model = service.GetMasterGroup();
            return View(model);
        }
        //get method! down below
    public ActionResult Create()
        {
            return View();
        }
     [HttpPost]
     [ValidateAntiForgeryToken]
     public ActionResult Create(MasterGroupCreate model)
        {
            if (!ModelState.IsValid) return View(model); //if its wrong then return the view so they can fix it

            var service = CreateMasterGroupService();
            //if its right step out of this loop interact with the service layer and create a new group model that is linked to their profile.

            if(service.CreateMasterGroup(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        public ActionResult Detials (int id)
        {
            var svc = CreateMasterGroupService();
            var model = svc.GetMasterGroupById(id);

            return View(model);
        }

        private MasterGroupService CreateMasterGroupService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MasterGroupService(userId);
            return service;
        }
    }

}