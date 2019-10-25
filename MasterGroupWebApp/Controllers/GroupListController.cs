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
    public class GroupListController : Controller
    {
        // GET: GroupList
        public ActionResult Index(int groupid)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GroupCheckListService(userId);
            var model = service.GetCheckLists(groupid);

            return View(model);
        }

        //Get method
        public ActionResult Create()
        {
            return View();
        }
        //post method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GroupCheckListCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GroupCheckListService(userId);
            var sv2 = service.CreateCheckList(model);

            if(sv2)
            {
                TempData["SaveResult"] = "Your Check List was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Check List could not be created.");

            return View(model);

        }
        public ActionResult CheckListDetails(int groupid)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GroupCheckListService(userId);
            var model = service.GetCheckListById(groupid);

            return View(model);
        }
        //Get//
        public ActionResult Edit(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GroupCheckListService(userId);
            var Jordan = service.GetCheckListById(id);

            var model = new CheckListEdit
            {
                Check1 = Jordan.Check1,
                Check2 = Jordan.Check2,
                Check3 = Jordan.Check3
            };

            return View(model);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,CheckListEdit model)
        {

            if (!ModelState.IsValid) return View(model);
            if (model.ListId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GroupCheckListService(userId);
            var svc1 = service.UpdateCheckList(model);
            if(svc1)
            {
                TempData["SaveResult"] = "Your Check List was updated.";
                return RedirectToAction("Detials","MasterGroup");
            }
            ModelState.AddModelError("", "Your Check List could not be updated.");

            return View(model);

        }
    }
}