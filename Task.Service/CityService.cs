using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Data.Infrastructure;
using Task.Data.Repositories;
using Task.Models;

namespace Task.Service
{
    public interface ICityService
    {
        IEnumerable<Mas_City> getcities();
        IEnumerable<Mas_City> getcity(int id);

    }
    class CityService : ICityService
    {
        private readonly ICityRepository cityRepository;
        private readonly IUnitOfWork unitOfWork;
        public CityService(ICityRepository cityRepository, IUnitOfWork unitOfWork)
        {
            this.cityRepository = cityRepository;
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<Mas_City> getcities()
        {
            return cityRepository.GetAll();
        }

        public IEnumerable<Mas_City> getcity(int id)
        {
            return cityRepository.getcity(id);
        }
    }
}
