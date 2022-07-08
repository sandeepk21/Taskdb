using Task.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Data.Configuration
{
    public class GenderConfiguration: EntityTypeConfiguration<Mas_Gender>
    {
        public GenderConfiguration()
        {
            ToTable("Mas_Gender");
            Property(g => g.Gender_Name).IsRequired().HasMaxLength(50);
            
        }
    }
}
