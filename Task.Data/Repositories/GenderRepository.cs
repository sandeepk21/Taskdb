using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Data.Infrastructure;
using Task.Models;

namespace Store.Data.Repositories
{
    public class GenderRepository : RepositoryBase<Mas_Gender>, IGenderRepository
    {
        public GenderRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Mas_Gender GetGenderByName(string GenderName)
        {
            var Mas_Gender = this.DbContext.Mas_Genders.Where(c => c.Gender_Name == GenderName).FirstOrDefault();

            return Mas_Gender;
        }
    }

    public interface IGenderRepository : IRepository<Mas_Gender>
    {
        Mas_Gender GetGenderByName(string GenderName);
    }
}
