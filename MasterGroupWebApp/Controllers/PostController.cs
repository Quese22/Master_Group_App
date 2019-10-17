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
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            var service = CreatePostService();
            service.CreatePost(model);

            return RedirectToAction("Index");
        }

        private PostServices CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostServices(userId);
            return service;
        }
    }
}