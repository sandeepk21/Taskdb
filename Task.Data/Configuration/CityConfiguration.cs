using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;

namespace Task.Data.Configuration
{
   public class CityConfiguration : EntityTypeConfiguration<Mas_City>
    {
        public CityConfiguration()
        {
            ToTable("Mas_City");
            Property(x => x.City_Name).IsRequired().HasMaxLength(50);
        }
    }
}
