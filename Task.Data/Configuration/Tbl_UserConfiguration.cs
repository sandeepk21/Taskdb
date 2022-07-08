using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;
using System.Data.Entity.ModelConfiguration;

namespace Task.Data.Configuration
{
   public class Tbl_UserConfiguration : EntityTypeConfiguration<Tbl_User>
    {
        public Tbl_UserConfiguration()
        {
            ToTable("Tbl_User");
            Property(y => y.FirstName).IsRequired().HasMaxLength(50);
            Property(y => y.LastName).IsRequired().HasMaxLength(50);
            Property(y => y.Username).IsRequired().HasMaxLength(50).IsUnicode();
            Property(y => y.RoleId).IsRequired();
            Property(y => y.GenderId).IsRequired();
            Property(y => y.CityId).IsRequired();
            Property(y => y.UserNickName).IsRequired().HasMaxLength(50);
            Property(y => y.Password).IsRequired().HasMaxLength(50);
            Property(y => y.Email).IsRequired().HasMaxLength(50).IsUnicode();


        }
    }
}
