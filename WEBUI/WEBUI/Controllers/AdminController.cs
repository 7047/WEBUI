using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBUI.Models;

namespace WEBUI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AdminLogin adminLogin)
        {
            string message = "";
            ViewBag.Message = message;
            using (WEBUIEntities5 dc = new WEBUIEntities5())
            {
                var v = dc.AdminLogins.Where(a => a.UserName == adminLogin.UserName).FirstOrDefault();
                if (v != null)
                {
                    if (string.Compare((adminLogin.Password), v.Password) == 0)
                    {
                        return RedirectToAction("index", "Home");
                    }
                    else
                    {
                        message = "Invalid Credential provided";
                    }
                }
                else
                {
                    message = "Invalid Credential provided";
                }

            }
            ViewBag.Message = message;
            return View();

        }
    }
        
  
    }
