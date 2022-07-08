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
    public interface IStateService
    {
       IEnumerable<Mas_State> getstate(int id);
    }
    public class StateService : IStateService
    {
        private readonly IStateRepository stateRepository;
        private readonly IUnitOfWork unitOfWork;
        public StateService(IStateRepository stateRepository, IUnitOfWork unitOfWork)
        {
            this.stateRepository = stateRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Mas_State> getstate(int id)
        {
            return stateRepository.getstatebyid(id);
        }
    }
}
