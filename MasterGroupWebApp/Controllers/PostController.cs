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
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            var service = CreatePostService();
            var model = service.GetPost();

            return View(model);
        }
        //Get//
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            ModelState.AddModelError("", "Post could not be created.");

            var service = CreatePostService();
            if(service.CreatePost(model))
            {
            return RedirectToAction("Detials", "MasterGroup", new { id = model.GroupID}) ; // I want to figure out how to have the comment then display on the page instead of a reroute to the index
            };

                
                return View(model);
        }

        public ActionResult Details (int id)
        {
            var svc = CreatePostService();
            var model = svc.GetPostById(id);

            return View(model);
        }

        //Get//
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePostService();
            var model = svc.GetPostById(id);

            return View(model);
        }

        //Post!//
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id, int groupId)
        {
            var service = CreatePostService();

            service.DeletePost(id);
            TempData["SaveResult"] = "Your post was deleted";

            return RedirectToAction("Detials","MasterGroup",new { id = groupId});
        }

        public PostServices CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostServices(userId);
            return service;
        }
    }
}