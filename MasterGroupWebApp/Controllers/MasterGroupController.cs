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

            ViewBag.Mine = service.GetMasterGroupForAll();


            return View(model);
        }
        public ActionResult IndexForAll()
        {
            var service = CreateMasterGroupService();
            var model = service.GetMasterGroupForAll();
            return View(model);
        }


        //get method! down below//
        public ActionResult Create()
        {
            return View();
        }

        //post method//
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterGroupCreate model)
        {
            if (!ModelState.IsValid) return View(model); //if its wrong then return the view so they can fix it

            var service = CreateMasterGroupService();
            //if its right step out of this loop interact with the service layer and create a new group model that is linked to their profile.

            if (service.CreateMasterGroup(model, User.Identity.Name))
            {
                TempData["SaveResult"] = "Your Group was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Group could not be created.");

            return View(model);
        }

        public ActionResult Detials(int id)
        {
            var svc = CreateMasterGroupService();
            var model = svc.GetMasterGroupById(id);

            var svc2 = new PostServices(Guid.Parse(User.Identity.GetUserId()));

            ViewBag.PostList = svc2.GetPostByGroupId(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMasterGroupService();
            var detail = service.GetMasterGroupById(id);
            var model =
                new MasterGroupEdit
                {
                    GroupId = detail.GroupId,
                    Subject = detail.Subject,
                    Name = detail.Name,
                    Description = detail.Description,
                    CheckItem1 = detail.CheckItem1,
                    CheckItem2 = detail.CheckItem2,
                    CheckItem3 = detail.CheckItem3,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterGroupEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GroupId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMasterGroupService();
            if(service.UpdateMasterGroup(model))
            {
                TempData["SaveResult"] = "Your Master Group was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Master Group could not be updated.");

            return View();
        }

        //Delete method requires a full detials preview before you delete the set up for view the detials first and then the set up to delete after
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMasterGroupService();
            var model = svc.GetMasterGroupById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGroup(int id)
        {
            var service = CreateMasterGroupService();
            service.DeleteMasterGroup(id);

            TempData["SaveResult"] = "Your Group was successfully deleted";

            return RedirectToAction("Index");
        }
        private MasterGroupService CreateMasterGroupService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MasterGroupService(userId);
            return service;
        }
    }
    

}