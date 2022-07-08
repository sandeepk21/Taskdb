using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Data.Infrastructure;
using Task.Data.Repositories;
using Task.Models;
using Task.Service;

namespace Task.Service
{
    public interface IUserService
    {
        IEnumerable<Tbl_User> GetUsers();
        
        //Role GetRole(int id);
        //Role GetRole(string name);
        bool CreateUser(Tbl_User tbl_User);
        void SaveUser();
        Tbl_User userlogin(Tbl_User us);
        Tbl_User getbyid(int id);
        bool updateuser(Tbl_User tbl_User);
        bool deletebyid(int id);
        Tbl_User getbysession(string email);
        IEnumerable<Tbl_User> getuserbyname(string name);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUserRepository userRepository,IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool CreateUser(Tbl_User tbl_User)
        {
          return  userRepository.CreateUser(tbl_User);
        }

        public IEnumerable<Tbl_User> GetUsers()
        {
            return userRepository.GetAll().ToList();
        }
        public Tbl_User userlogin(Tbl_User us)
        {
            var tbl_user = userRepository.getbyemail(us);
            
            return tbl_user;
        }
        public void SaveUser()
        {
            throw new NotImplementedException();
        }

        public Tbl_User getbyid(int id)
        {
            return userRepository.getbyid(id);
        }

        public bool updateuser(Tbl_User tbl_User)
        {
            return userRepository.updateuser(tbl_User);
        }

        public bool deletebyid(int id)
        {
            return userRepository.deletebyid(id);
        }

        public Tbl_User getbysession(string email)
        {
            return userRepository.getbysession(email);
        }

        public IEnumerable<Tbl_User> getuserbyname(string name)
        {
            return userRepository.getuserbyname(name);
        }
    }
}
