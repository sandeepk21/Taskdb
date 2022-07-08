using Task.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Data.Configuration
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            ToTable("Role");
            Property(c => c.Role_Name).IsRequired().HasMaxLength(50);
        }
    }
}
