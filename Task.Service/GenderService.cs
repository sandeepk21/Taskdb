using Store.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Data;
using Task.Data.Infrastructure;
using Task.Models;

namespace Task.Service
{
    public interface IGenderService
    {
        void CreateGender(Mas_Gender gender);
        Mas_Gender GetGender(int id);
        Mas_Gender GetGender(string name);
        IEnumerable<Mas_Gender> GetGenders();
        void SaveGender();



    }
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository gendersRepository;
        private readonly IUnitOfWork unitOfWork;

        public GenderService(IGenderRepository gendersRepository, IUnitOfWork unitOfWork)
        {
            this.gendersRepository = gendersRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateGender(Mas_Gender gender)
        {
            gendersRepository.Add(gender);
        }

        public IEnumerable<Mas_Gender> GetGenders()
        {
            //if (string.IsNullOrEmpty(name))
            //    return gendersRepository.GetAll();
            //else
            //    return gendersRepository.GetAll().Where(c => c.Gender_Name == name);
            return gendersRepository.GetAll();
        }

        public Mas_Gender GetGender(int id)
        {
            var mas_Gender = gendersRepository.GetById(id);
            return mas_Gender;
        }

        public void SaveGender()
        {
            unitOfWork.Commit();
        }

        public Mas_Gender GetGender(string name)
        {
            var Mas_Gender = gendersRepository.GetGenderByName(name);
            return Mas_Gender;
        }




    }
}
