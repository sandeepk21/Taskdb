namespace Task.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Task.Models;

    public class Configuration : DbMigrationsConfiguration<StoreEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StoreEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method
            //to avoid creating duplicate seed data.
            //GetRoles().ForEach(c => context.Roles.Add(c));
            //GetGender().ForEach(g => context.Mas_Genders.Add(g));
            //GetCountry().ForEach(a => context.Mas_Country.Add(a));
            //GetState().ForEach(b => context.Mas_State.Add(b));
            GetCity().ForEach(x => context.Mas_City.Add(x));
            //GetUser().ForEach(y => context.Tbl_Users.Add(y));
            //GetEmployee().ForEach(z => context.Tbl_Employees.Add(z));


            context.Commit();
        }
        //private static List<Tbl_User> GetUser()
        //{
        //    return new List<Tbl_User>
        //    {
        //        new Tbl_User
        //        {
        //            FirstName="Sandeep",
        //            LastName="Kumar",
        //            Username="Sandeep21",
        //            RoleId=1,
        //            GenderId=1,
        //            CityId=1,
        //            UserNickName="Sandy",
        //            Password="1234",
        //            Email="Sandeep@gmail.com"
        //        }
        //    };
        //}



        //private static List<Role> GetRoles()
        //{
        //    return new List<Role>
        //        {
        //            new Role {

        //                Role_Name="Administrator"
        //            },
        //            new Role {

        //                Role_Name="User"
        //            }


        //        };
        //}

        //private static List<Mas_Gender> GetGender()
        //{
        //    return new List<Mas_Gender>
        //        {
        //            new Mas_Gender {

        //                Gender_Name="Male"
        //            },
        //             new Mas_Gender {

        //                Gender_Name="Female"
        //            }


        //        };

        //}
        //private static List<Mas_Country> GetCountry()
        //{
        //    return new List<Mas_Country>
        //    {
        //        new Mas_Country
        //        {
        //            Country_Name="India"
        //        }
        //    };
        //}
        //private static List<Mas_State> GetState()
        //{
        //    return new List<Mas_State>
        //    {
        //        new Mas_State
        //        {
        //            State_Name="Uttar Pradesh",
        //            CountryId=1

        //        }

        //    };
        //}
        private static List<Mas_City> GetCity()
        {
            return new List<Mas_City>
            {
                new Mas_City
                {
                    City_Name="Lucknow",
                    StateId=1


                }

            };
        }

    }
}
