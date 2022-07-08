using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Data.Infrastructure;
using Task.Models;

namespace Task.Data.Repositories
{
     public class StateRepository : RepositoryBase<Mas_State>, IStateRepository
    {
        public StateRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public IEnumerable<Mas_State> getstatebyid(int id)
        {
           return this.DbContext.Mas_State.Where(c => c.CountryId == id).ToList();
           
        }
    }
    public interface IStateRepository : IRepository<Mas_State>
    {
       IEnumerable<Mas_State> getstatebyid(int id);
    }
}
