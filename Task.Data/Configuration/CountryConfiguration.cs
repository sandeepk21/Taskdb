using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;

namespace Task.Data.Configuration
{
    public class CountryConfiguration : EntityTypeConfiguration<Mas_Country>
    {
        public CountryConfiguration()
        {
            ToTable("Mas_Country");
            Property(a => a.Country_Name).IsRequired().HasMaxLength(50);
            
        }
    }
}
