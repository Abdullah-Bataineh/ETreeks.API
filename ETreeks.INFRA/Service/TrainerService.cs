using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.INFRA.Service
{
    public class TrainerService : IService<Trainer>,ITrainerService
    {
        private readonly IRepository<Trainer> _trainerRepository;
        private readonly ITrainerRepository _repositry;

        public TrainerService(IRepository<Trainer> trainerRepository, ITrainerRepository repositry)
        {
            _trainerRepository = trainerRepository;
            _repositry = repositry;
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

        public List<KeyValuePair<string,int>> CreateTrainer(TrainerLogin trainerlogin)
        {
            return _repositry.CreateTrainer(trainerlogin);
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

        public trainerEmail getTrainerEmailbyId(int id)
        {
            return _repositry.getTrainerEmailbyId(id);
        }

        public List<TrainerUser> GetTrainerUser()
        {
            return _repositry.GetTrainerUser();
        }

        public List<TrainerUser> GetTrainerUserByUserId(int id)
        {
            return _repositry.GetTrainerUserByUserId(id);
        }

        public List<TrainerUser> searchTrainer(string name)
        {
            return _repositry.searchTrainer(name);
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

        public void UpdateTrainer(TrainerLogin trainerLogin)
        {
             _repositry.UpdateTrainer(trainerLogin);
        }
    }
}
