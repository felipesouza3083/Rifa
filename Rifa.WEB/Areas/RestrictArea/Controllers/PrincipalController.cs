using Rifa.WEB.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rifa.WEB.Areas.RestrictArea.Controllers
{
    [Authorize]
    public class PrincipalController : Controller
    {
        // GET: RestrictArea/Principal
        [NoCache]
        public ActionResult Index()
        {
            return View();
        }
    }
}