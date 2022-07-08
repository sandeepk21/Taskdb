using Task.Data;
using Task.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Data.Configuration;

namespace Task.Data
{
    public class StoreEntities : DbContext
    {
        public StoreEntities() : base("StoreEntities") { }

        public virtual DbSet<Mas_City> Mas_City { get; set; }
        public virtual DbSet<Mas_Country> Mas_Country { get; set; }
        public virtual DbSet<Mas_State> Mas_State { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Mas_Gender> Mas_Genders { get; set; }
        public virtual DbSet<Tbl_User> Tbl_Users { get; set; }
        public virtual DbSet<Tbl_Employee> Tbl_Employees { get; set; }


        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new GenderConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new StateConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new Tbl_UserConfiguration());
            modelBuilder.Configurations.Add(new Tbl_EmployeeConfiguration());

        }

        



        //public System.Data.Entity.DbSet<Task.Web.ViewModel.RoleViewModel> RoleViewModels { get; set; }

        //public System.Data.Entity.DbSet<Task.Web.ViewModel.Mas_GenderViewModel> Mas_GenderViewModel { get; set; }
    }
}
