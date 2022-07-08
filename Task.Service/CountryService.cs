using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;
using Task.Data;
using Task.Data.Infrastructure;
using Task.Data.Repositories;

namespace Task.Service
{
    public interface ICountryService
    {
        IEnumerable<Mas_Country> getcountry();
    }
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;
        private readonly IUnitOfWork unitOfWork;
        public CountryService(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
        {
            this.countryRepository = countryRepository;
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<Mas_Country> getcountry()
        {
            return countryRepository.GetAll();
        }
    }
}
