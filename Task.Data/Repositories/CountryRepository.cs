using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;
using Task.Data.Infrastructure;

namespace Task.Data.Repositories
{
    public class CountryRepository : RepositoryBase<Mas_Country>, ICountryRepository
    {
        public CountryRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

    }
    public interface ICountryRepository : IRepository<Mas_Country>
    {

    }
}
