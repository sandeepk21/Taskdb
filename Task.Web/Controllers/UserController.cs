using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Service;
using Task.Models;
using Task.Data;
using Task.Web.ViewModel;
namespace Task.Web.Controllers
{
    public class UserController : Controller
    {
        public UserController() { }
        private readonly IRoleService rolesService;
        private readonly IGenderService genderService;
        private readonly IUserService userService;
        private readonly ICityService cityService;
        private readonly IStateService stateService;
        private readonly ICountryService countryService;
        private readonly IEmployeeService employeeService;
        public UserController(IRoleService roleService, IGenderService genderService, IUserService userService, ICityService cityService, IStateService stateService, ICountryService countryService, IEmployeeService employeeService)
        {
            this.rolesService = roleService;
            this.genderService = genderService;
            this.userService = userService;
            this.cityService = cityService;
            this.stateService = stateService;
            this.countryService = countryService;
            this.employeeService = employeeService;
        }
        // GET: User
        public ActionResult Index()
        {
            if (Session["useremail"] != null)
            {
                string email = Session["useremail"].ToString();
                Tbl_User tbl_User = userService.getbysession(email);
                Tbl_UserViewModel tbl_UserViewModel = new Tbl_UserViewModel();
                AutoMapper.Mapper.Map(tbl_User,tbl_UserViewModel);

                return View(tbl_UserViewModel);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        public ActionResult Employees()
        {
            if (Session["useremail"] != null)
            {


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
    }
}