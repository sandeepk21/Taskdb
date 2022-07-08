using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Service;
using Task.Web.ViewModel;
using Task.Models;
using Task.Data;



namespace Task.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController() { }
        private readonly IRoleService rolesService;
        private readonly IGenderService genderService;
        private readonly IUserService userService;
        public HomeController(IRoleService roleService,IGenderService genderService,IUserService userService)
        {
            this.rolesService = roleService;
            this.genderService = genderService;
            this.userService = userService;
        }

        // GET: Homes
        public ActionResult Index(Tbl_EmployeeViewModel vuser)
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(Tbl_UserViewModel vuser)
        {

            //List<Tbl_UserViewModel> userviewlist = new List<Tbl_UserViewModel>();
            //userviewlist.Add(vuser);
            //List<Tbl_User> userlist = new List<Tbl_User>();
            //AutoMapper.Mapper.Map(userviewlist,userlist);
            Tbl_User us = new Tbl_User();
            us.Email = vuser.Email;
            us.Password = vuser.Password;
            var tbl_User = userService.userlogin(us);
            if (tbl_User != null)
            {
                if(tbl_User.RoleId==1)
                {
                    Session["email"] = tbl_User.Email.ToString();
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    Session["useremail"] = tbl_User.Email.ToString();
                    return RedirectToAction("Index", "User");
                }
                
            }
            else
            {
                Response.Write("<script>alert('data not found')</script>");
                return View("index");
            }
            
           
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
       
    }
}