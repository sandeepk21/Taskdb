using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;

namespace Task.Data.Configuration
{
   public class Tbl_EmployeeConfiguration : EntityTypeConfiguration<Tbl_Employee>
    {
        public Tbl_EmployeeConfiguration()
        {
            ToTable("Tbl_Employee");
            Property(z => z.FirstName).IsRequired().HasMaxLength(50);
            Property(z => z.LastName).IsRequired().HasMaxLength(50);
            Property(z => z.GenderId).IsRequired();
            Property(z => z.CityId).IsRequired();
            Property(z => z.Email).IsRequired().HasMaxLength(50).IsUnicode();
            Property(z => z.Password).IsRequired().HasMaxLength(50);
            Property(z => z.Address).IsRequired().HasMaxLength(50);
            Property(z => z.Pincode).IsRequired();
            Property(z => z.JoiningDate).IsRequired();
            Property(z => z.LastWorkingDate);
            Property(z => z.IsActive).IsRequired();

        }
    }
}
