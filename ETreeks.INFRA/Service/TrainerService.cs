using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.INFRA.Service
{
    public class TrainerService : IService<Trainer>
    {
        private readonly IRepository<Trainer> _trainerRepository;

        public TrainerService(IRepository<Trainer> trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }

        public bool Create(Trainer trainer)
        {
            int result;
            result = _trainerRepository.Create(trainer);
            if (result == 1)
                return true;
            else
                return false;
        }

        public bool Delete(int id)
        {
            int result;
            result = _trainerRepository.Delete(id);
            if (result == 1)
                return true;
            else
                return false;
        }

        public List<Trainer> GetAll()
        {
            return _trainerRepository.GetAll();
        }

        public Trainer GetById(int id)
        {
            return _trainerRepository.GetById(id);
        }

        public bool Update(Trainer trainer)
        {
            int result;
            result = _trainerRepository.Update(trainer);
            if (result == 1)
                return true;
            else
                return false;
        }
    }
}
