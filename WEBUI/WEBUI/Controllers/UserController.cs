using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WEBUI.Models;

namespace WEBUI.Controllers
{
    public class UserController : Controller
    {
        // Registration Action
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(UserRegister user)
        {
            bool Status = false;
            string message = "";
            // Model Validation
            if (ModelState.IsValid)
            {
                // //Email is already Exist
                var isExist = IsEmailExist(user.Email);
                if (isExist)
                {
                    ModelState.AddModelError("Email Exist", "Email Address already exist");
                    return View(user);
                }
                #region Password Hashing
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                #endregion
                #region Save to Database
                using (WEBUIEntities dc = new WEBUIEntities())
                {
                    dc.UserRegisters.Add(user);
                    dc.SaveChanges();
                    // SendVerificationLinkEmail(user.EmailID, user.ActivationCode.ToString());
                    message = "Registration Successfully done";
                    Status = true;
                }
                #endregion

            }
            else

            {
                message = "InValid Request";
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;

            //Generate Activation Code

            //Password Hashing
            //Save data to database
            //Send Email to user


            return View(user);
        }
        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            using (WEBUIEntities dc = new WEBUIEntities())
            {
                var v = dc.UserRegisters.Where(a => a.Email == emailID).FirstOrDefault();
                return v != null;
            }
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(UserLogin login, string ReturnUrl)
        {
            string message = "";
            ViewBag.Message = message;
            using (WEBUIEntities dc = new WEBUIEntities())
            {
                var v = dc.UserRegisters.Where(a => a.Email == login.Email).FirstOrDefault();
                if (v != null)
                {

                    if (string.Compare(Crypto.Hash(login.Password), v.Password) == 0)
                    {
                        int timeout = login.RememerMe ? 525600 : 1;
                        var ticket = new FormsAuthenticationTicket(login.Email, login.RememerMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);
                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("index", "Home");
                        }
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
        [NonAction]
        public ActionResult Countrylist()
        {
            List<SelectListItem> li = new List<SelectListItem>();
            SelectListItem li1 = new SelectListItem() { Text = "India", Value = "1" };
            SelectListItem li2 = new SelectListItem() { Text = "UK", Value = "2" };
            SelectListItem li3 = new SelectListItem() { Text = "Nepal", Value = "3" };
            SelectListItem li4 = new SelectListItem() { Text = "Germany", Value = "4" };
            li.Add(li1);
            li.Add(li2);
            li.Add(li3);
            li.Add(li4);
            ViewBag.Countries = li;
            return View();

        }
    }
}