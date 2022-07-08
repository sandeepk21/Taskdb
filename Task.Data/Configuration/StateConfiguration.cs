using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;

namespace Task.Data.Configuration
{
    public class StateConfiguration : EntityTypeConfiguration<Mas_State>
    {
        public StateConfiguration()
        {
            ToTable("Mas_State");
            Property(b => b.State_Name).IsRequired().HasMaxLength(50);
        }
    }
}
