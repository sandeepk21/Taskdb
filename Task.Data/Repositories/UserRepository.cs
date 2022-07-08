using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Data.Infrastructure;
using Task.Models;

namespace Task.Data.Repositories
{
   public  class UserRepository : RepositoryBase<Tbl_User>,IUserRepository
    {
        public UserRepository(IDbFactory dbFactory)
           : base(dbFactory) { }

        public bool CreateUser(Tbl_User tbl_User)
        {
            try
            {


                this.DbContext.Tbl_Users.Add(tbl_User);
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

        public bool deletebyid(int id)
        {
           var vv= this.DbContext.Tbl_Users.Where(c => c.UserId == id).FirstOrDefault();
            //this.DbContext.Entry(vv).State = System.Data.Entity.EntityState.Deleted;
            this.DbContext.Tbl_Users.Remove(vv);
           int n= DbContext.SaveChanges();
            if(n==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Tbl_User getbyemail(Tbl_User us)
        {
            var tbl_User = this.DbContext.Tbl_Users.Where(c => c.Email==us.Email && c.Password==us.Password).FirstOrDefault();
    
            return tbl_User;
        }

        public Tbl_User getbyid(int id)
        {
            var tbl_User = this.DbContext.Tbl_Users.Where(c => c.UserId == id).FirstOrDefault();
            return tbl_User;
        }

        public Tbl_User getbysession(string email)
        {
           var tbl_User = this.DbContext.Tbl_Users.Where(c => c.Email == email).FirstOrDefault();
            return tbl_User;
        }

        public IEnumerable<Tbl_User> getuserbyname(string name)
        {
            return this.DbContext.Tbl_Users.Where(c => c.FirstName == name || c.LastName == name || c.Email == name || c.Username == name || c.UserNickName == name).ToList();
        }

        public bool updateuser(Tbl_User tbl_User)
        {
            this.DbContext.Entry(tbl_User).State = System.Data.Entity.EntityState.Modified;
          int n= DbContext.SaveChanges();
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
    public interface IUserRepository : IRepository<Tbl_User>
    {

        Tbl_User getbyemail(Tbl_User us);
        bool CreateUser(Tbl_User tbl_User);
        Tbl_User getbyid(int id);
        bool updateuser(Tbl_User tbl_User);
        bool deletebyid(int id);
        Tbl_User getbysession(string email);
        IEnumerable<Tbl_User> getuserbyname(string name);
    }
}
