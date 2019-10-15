using MasterGroup.Models;
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
            var model = new MasterGroupItem[0];
            return View();
        }
    }
}