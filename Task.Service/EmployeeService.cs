using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Data.Infrastructure;
using Task.Data.Repositories;
using Task.Models;

namespace Task.Service
{
    public interface IEmployeeService
    {
        bool createemployee(Tbl_Employee tbl_Employee);
        void createemp(Tbl_Employee tbl_Employee);
        void Saveemp();
        Tbl_Employee getbyid(int id);
        IEnumerable<Tbl_Employee> getemployees();
        bool updateemployee(Tbl_Employee tbl_Employee);
        bool updatebyid(int id,int active);
        IEnumerable<Tbl_Employee> getbyemail(string email);
        IEnumerable<Tbl_Employee> getbyname(string name);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IUnitOfWork unitOfWork;
        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            this.employeeRepository = employeeRepository;
            this.unitOfWork = unitOfWork;
        }

        public void createemp(Tbl_Employee tbl_Employee)
        {
            employeeRepository.Add(tbl_Employee);
        }

        public bool createemployee(Tbl_Employee tbl_Employee)
        {
            return employeeRepository.createemployee(tbl_Employee);
        }

        public IEnumerable<Tbl_Employee> getbyemail(string email)
        {
            return employeeRepository.getbyemail(email);
        }

        public Tbl_Employee getbyid(int id)
        {
            return employeeRepository.getbyid(id);
        }

        public IEnumerable<Tbl_Employee> getbyname(string name)
        {
            return employeeRepository.getbyname(name);
        }

        public IEnumerable<Tbl_Employee> getemployees()
        {
            return employeeRepository.GetAll().ToList();
        }

        public void Saveemp()
        {
            unitOfWork.Commit();
        }

        public bool updatebyid(int id,int active)
        {
            return employeeRepository.updatebyid(id,active);
        }

        public bool updateemployee(Tbl_Employee tbl_Employee)
        {
            return employeeRepository.updateemployee(tbl_Employee);
        }
    }
}
