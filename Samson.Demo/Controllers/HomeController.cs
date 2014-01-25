using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Samson.Demo.Models;
using Samson.Services;
using Samson.Standard.Mvc;

namespace Samson.Demo.Controllers
{
    public class HomeController : SamsonSurfaceController
    {
        public HomeController(IStrongContentService contentService, IStrongMediaService mediaService)
            : base (contentService, mediaService)
        {
        }

        public ActionResult Index()
        {
            var current = StrongContentService.GetCurrentNode();

            return View("~/Views/Partials/HomeView.cshtml", new HomeModel { Title = current.Name });
        }
    }
}
