using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;
using Task.Data.Infrastructure;

namespace Task.Data.Repositories
{
    public class CityRepository : RepositoryBase<Mas_City>, ICityRepository
    {
        public CityRepository(IDbFactory dbFactory)
           : base(dbFactory) { }

        public IEnumerable<Mas_City> getcity(int id)
        {
            return this.DbContext.Mas_City.Where(c => c.StateId == id).ToList();
        }
    }
    public interface ICityRepository : IRepository<Mas_City>
    {
        IEnumerable<Mas_City> getcity(int id);
        
    }
}
