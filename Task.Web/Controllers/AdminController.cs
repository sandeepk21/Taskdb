using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Service;
using Task.Web.ViewModel;
using Task.Models;

namespace Task.Web.Controllers
{
    public class AdminController : Controller
    {
        public AdminController() { }
        private readonly IRoleService rolesService;
        private readonly IGenderService genderService;
        private readonly IUserService userService;
        private readonly ICityService cityService;
        private readonly IStateService stateService;
        private readonly ICountryService countryService;
        private readonly IEmployeeService employeeService;
        public AdminController(IRoleService roleService, IGenderService genderService, IUserService userService,ICityService cityService,IStateService stateService,ICountryService countryService,IEmployeeService employeeService)
        {
            this.rolesService = roleService;
            this.genderService = genderService;
            this.userService = userService;
            this.cityService = cityService;
            this.stateService = stateService;
            this.countryService = countryService;
            this.employeeService = employeeService;
        }
        public void lists()
        {
            List<Mas_Gender> genderlist = genderService.GetGenders().ToList();
            List<Mas_GenderViewModel> genderviewlist = new List<Mas_GenderViewModel>();
            AutoMapper.Mapper.Map(genderlist, genderviewlist);
            ViewBag.genderlist = new SelectList(genderviewlist, "GenderId", "Gender_Name");
            List<Role> rolelist = rolesService.GetRoles().ToList();
            ViewBag.rolelist = new SelectList(rolelist, "RoleId", "Role_Name");
            List<Mas_Country> countrylist = countryService.getcountry().ToList();
            ViewBag.country = new SelectList(countrylist, "CountryId", "Country_Name");
        }
        // GET: Admin
        public ActionResult Index()
        {
            if(Session["email"]==null)
            {

                return RedirectToAction("Index", "Home");
            }
            else
            {
                string email = Session["email"].ToString();
                Tbl_User tbl_User = userService.getbysession(email);
                Tbl_UserViewModel tbl_UserViewModel = new Tbl_UserViewModel();
                AutoMapper.Mapper.Map(tbl_User, tbl_UserViewModel);
                return View(tbl_UserViewModel);
            }
            
        }
        public ActionResult AddUser()
        {
            if (Session["email"] != null)
            {

                lists();
                Tbl_UserViewModel dd = new Tbl_UserViewModel();
                List<Tbl_User> userlist = userService.GetUsers().ToList();
                List<Tbl_UserViewModel> Userlist = new List<Tbl_UserViewModel>();
                AutoMapper.Mapper.Map(userlist, Userlist);
                return View(Userlist);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public JsonResult AddUser(Tbl_UserViewModel vuser)
        {
            Tbl_User tbl_user = new Tbl_User();
            AutoMapper.Mapper.Map(vuser, tbl_user);
            bool n=userService.CreateUser(tbl_user);
            if(n==true)
            {
                
                return Json("<span>data save !!</span>",JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("<span>data not save !!</span>", JsonRequestBehavior.AllowGet);
            }
            
        }
        public ActionResult Users()
        {
            if (Session["email"] != null)
            {


                List<Tbl_User> userlist = userService.GetUsers().ToList();
                List<Tbl_UserViewModel> Userlist = new List<Tbl_UserViewModel>();
                
                
                AutoMapper.Mapper.Map(userlist, Userlist);

                return View(Userlist);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public JsonResult Bindstate(int id)
        {
            List<Mas_State> statelist = stateService.getstate(id).ToList();
            List<StateView> stateviewlist = new List<StateView>();
            AutoMapper.Mapper.Map(statelist, stateviewlist);
            return Json(stateviewlist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Bindcity(int id)
        {
            List<Mas_City> citylist = cityService.getcity(id).ToList();
            List<CityView> cityviewlist = new List<CityView>();
            AutoMapper.Mapper.Map(citylist, cityviewlist);
            return Json(cityviewlist, JsonRequestBehavior.AllowGet);

        }
        public ActionResult AddEmployee()
        {
            if (Session["email"] != null)
            {

                lists();
              
                List<Tbl_Employee> employeelist = employeeService.getemployees().ToList();
                List<Tbl_EmployeeViewModel> empviewlist = new List<Tbl_EmployeeViewModel>();

                AutoMapper.Mapper.Map(employeelist, empviewlist);
                return View(empviewlist);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public JsonResult AddEmployee(Tbl_EmployeeViewModel vemp)
        {
            vemp.IsActive = 1;
            Tbl_Employee tbl_Employee = new Tbl_Employee();
            AutoMapper.Mapper.Map(vemp, tbl_Employee);
            bool n = employeeService.createemployee(tbl_Employee);
            if (n == true)
            {
                string email = tbl_Employee.Email;
                List<Tbl_Employee> emplist = employeeService.getbyemail(email).ToList();
                List<Tbl_EmployeeViewModel> empviewlist = new List<Tbl_EmployeeViewModel>();
                AutoMapper.Mapper.Map(emplist, empviewlist);
                
                return Json("Save Data !!", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("not save data !!", JsonRequestBehavior.AllowGet);
            }
           


        }
        public ActionResult EmployeeEdit(int id)
        {
            if (Session["email"] != null)
            {
                lists();
                List<SelectListItem> act = new List<SelectListItem>();
                act.Add(new SelectListItem { Value = "0", Text = "Deactivate" });
                act.Add(new SelectListItem { Value = "1", Text = "Activate" });
                ViewBag.act = new SelectList(act, "Value", "Text");
                Tbl_Employee emp = employeeService.getbyid(id);
                Tbl_EmployeeViewModel empview = new Tbl_EmployeeViewModel();
                AutoMapper.Mapper.Map(emp, empview);
                return View(empview);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public JsonResult EmployeeEdit(Tbl_EmployeeViewModel vemp)
        {
            Tbl_Employee tbl_Employee = new Tbl_Employee();
            AutoMapper.Mapper.Map(vemp, tbl_Employee);
            bool n = employeeService.updateemployee(tbl_Employee);
            if(n==true)
            {
                return Json("update successfully", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("not update", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult EmployeeActive(int id)
        {
            int active = 1;
            bool n = employeeService.updatebyid(id,active);
            if(n==true)
            {
                 return RedirectToAction("AddEmployee", "Admin");
            }
            else
            {
               return RedirectToAction("AddEmployee", "Admin");
            }
            
        }
        public ActionResult EmployeeDeActive(int id)
        {
            int active = 0;
            bool n = employeeService.updatebyid(id, active);
            if (n == true)
            {
                return RedirectToAction("AddEmployee", "Admin");
            }
            else
            {
                return RedirectToAction("AddEmployee", "Admin");
            }

        }

        public ActionResult UserEdit(int id)
        {
            if (Session["email"] != null)
            {
                lists();
                Tbl_User tbl_User = userService.getbyid(id);
                Tbl_UserViewModel tbl_UserViewModel = new Tbl_UserViewModel();
                AutoMapper.Mapper.Map(tbl_User, tbl_UserViewModel);
                return View(tbl_UserViewModel);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public JsonResult UserEdit(Tbl_UserViewModel tbl_UserViewModel)
        {
            Tbl_User tbl_User = new Tbl_User();
            AutoMapper.Mapper.Map(tbl_UserViewModel, tbl_User);
            bool n=userService.updateuser(tbl_User);
            if(n==true)
            {
                return Json("update successfully", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("not done", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult UserDelete(int id)
        {
           bool n=userService.deletebyid(id);
            if(n==true)
            {
                return RedirectToAction("AddUser", "Admin");
            }
            else
            {
                return RedirectToAction("AddUser", "Admin");
            }
            
        }
        public ActionResult Searchemp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Searchemp(string SearchFirstName)
        {
            if (SearchFirstName == "" || SearchFirstName == null)
            {
                List<Tbl_Employee> emplist = employeeService.getemployees().ToList();
                List<Tbl_EmployeeViewModel> empviewlist = new List<Tbl_EmployeeViewModel>();
                AutoMapper.Mapper.Map(emplist, empviewlist);
                return PartialView("Searchemp", empviewlist);
            }
            else
            {

                List<Tbl_Employee> emplist = employeeService.getbyname(SearchFirstName).ToList();
                List<Tbl_EmployeeViewModel> empviewlist = new List<Tbl_EmployeeViewModel>();
                AutoMapper.Mapper.Map(emplist, empviewlist);
                return PartialView("Searchemp", empviewlist);
            }
        }
        public ActionResult SearchUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchUser(string SearchFirstName)
        {
            if (SearchFirstName == "" || SearchFirstName == null)
            {
                List<Tbl_User> userlist = userService.GetUsers().ToList();
                List<Tbl_UserViewModel> userviewlist = new List<Tbl_UserViewModel>();
                AutoMapper.Mapper.Map(userlist, userviewlist);
                return PartialView("SearchUser", userviewlist);
            }
            else
            {
                List<Tbl_User> userlist = userService.getuserbyname(SearchFirstName).ToList();
                List<Tbl_UserViewModel> userviewlist = new List<Tbl_UserViewModel>();
                AutoMapper.Mapper.Map(userlist, userviewlist);
                return PartialView("SearchUser", userviewlist);

            }
           
        }
    }
}