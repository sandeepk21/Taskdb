using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Data.Infrastructure;
using Task.Models;

namespace Task.Data.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        //public Role GetRoleByName(string rolename)
        //{
        //    var role = this.DbContext.Roles.Where(c => c.Role_Name == rolename).FirstOrDefault();

        //    return role;
        //}

        //public override void Update(Role entity)
        //{
        //    base.Update(entity);
        //}
    }

    public interface IRoleRepository : IRepository<Role>
    {
        //Role GetRoleByName(string roleName);
    }
}
