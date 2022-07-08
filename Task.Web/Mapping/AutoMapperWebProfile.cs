using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task.Web.ViewModel;
using Task.Models;
using Task.Data;
using Task.Service;
using AutoMapper;

namespace Task.Web.Mapping
{
    public class AutoMapperWebProfile : Profile
    {
        public AutoMapperWebProfile()
        {
            CreateMap<Tbl_User,Tbl_UserViewModel>();
            CreateMap<Tbl_UserViewModel,Tbl_User>();
            CreateMap<Mas_Gender, Mas_GenderViewModel>();
            CreateMap<Mas_GenderViewModel, Mas_Gender>();
            CreateMap<Role, RoleViewModel>();
            CreateMap<RoleViewModel, Role>();
            CreateMap<Mas_State, StateView>();
            CreateMap<StateView, Mas_State>();
            CreateMap<Mas_City, CityView>();
            CreateMap<CityView, Mas_City>();
            CreateMap<Tbl_Employee, Tbl_EmployeeViewModel>();
            CreateMap<Tbl_EmployeeViewModel, Tbl_Employee>();
        }

        public static void Run()
        {
            Mapper.Initialize(a =>
            {
                a.AddProfile<AutoMapperWebProfile>();
            });

        }
    }
}