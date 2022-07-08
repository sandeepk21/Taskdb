using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;
using Task.Data.Infrastructure;

namespace Task.Data.Repositories
{
    public class EmployeeRepository : RepositoryBase<Tbl_Employee>,IEmployeeRepository
    {
        public EmployeeRepository(IDbFactory dbFactory)
           : base(dbFactory) { }

        public bool createemployee(Tbl_Employee tbl_Employee)
        {
            try
            {
                this.DbContext.Tbl_Employees.Add(tbl_Employee);
                int n = DbContext.SaveChanges();
                if (n == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Tbl_Employee> getbyemail(string email)
        {
            return this.DbContext.Tbl_Employees.Where(c => c.Email == email).ToList();
        }

        public Tbl_Employee getbyid(int id)
        {
            var tbl_Employee = this.DbContext.Tbl_Employees.Where(c => c.EmployeeId == id).FirstOrDefault();
            return tbl_Employee;
        }

        public IEnumerable<Tbl_Employee> getbyname(string name)
        {
            return this.DbContext.Tbl_Employees.Where(c => c.FirstName == name || c.LastName==name ||c.Email==name).ToList();
        }

        public bool updatebyid(int id,int active)
        {
            var vv=this.DbContext.Tbl_Employees.Where(c => c.EmployeeId == id).FirstOrDefault();
            vv.IsActive = active;
            this.DbContext.Entry(vv).State = System.Data.Entity.EntityState.Modified;
            int n = DbContext.SaveChanges();
            if (n == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool updateemployee(Tbl_Employee tbl_Employee)
        {
            this.DbContext.Entry(tbl_Employee).State = System.Data.Entity.EntityState.Modified;
            int n = DbContext.SaveChanges();
            if(n==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public interface IEmployeeRepository : IRepository<Tbl_Employee>
    {
        bool createemployee(Tbl_Employee tbl_Employee);
        Tbl_Employee getbyid(int id);
        bool updateemployee(Tbl_Employee tbl_Employee);
        bool updatebyid(int id,int active);
        IEnumerable<Tbl_Employee> getbyemail(string email);
        IEnumerable<Tbl_Employee> getbyname(string name);
    }

}
