using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;
using Task.Data;
using Task.Data.Repositories;
using Task.Data.Infrastructure;

namespace Task.Service
{
    public interface IRoleService
    {
        IEnumerable<Role> GetRoles();
        IEnumerable<Role> gethi();
        //Role GetRole(int id);
        //Role GetRole(string name);
        void CreateRole(Role role);
        void SaveRole();
    }
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository rolesRepository;
        private readonly IUnitOfWork unitOfWork;

        public RoleService(IRoleRepository rolesRepository, IUnitOfWork unitOfWork)
        {
            this.rolesRepository = rolesRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateRole(Role role)
        {
            rolesRepository.Add(role);
        }

        public IEnumerable<Role> GetRoles()
        {
            //if (name=="")
            //    return rolesRepository.GetAll();
            //else
            //    return rolesRepository.GetAll().Where(c => c.Role_Name == name);
            return rolesRepository.GetAll();
        }
        public IEnumerable<Role> gethi()
        {
            return rolesRepository.GetAll();
        }


        public Role GetRole(int id)
        {
            var Role = rolesRepository.GetById(id);
            return Role;
        }

        public void SaveRole()
        {
            unitOfWork.Commit();
        }

        //public Role GetRole(string name)
        //{
        //    //var Role = rolesRepository.GetRoleByName(name);
        //    return Role;
        //}
    }
}
