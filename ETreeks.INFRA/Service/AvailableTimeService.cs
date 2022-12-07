using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.INFRA.Service
{
    public class AvailableTimeService : IService<AvailableTime>,IAvailableTimeService
    {
        private readonly IRepository<AvailableTime> _availableTimeRepository;
        private readonly IAvailableTimeRepository _availableTimeRepository2;
        public AvailableTimeService(IRepository<AvailableTime> availableTimeRepository, IAvailableTimeRepository availableTimeRepository2)
        {
            _availableTimeRepository = availableTimeRepository;
            _availableTimeRepository2 = availableTimeRepository2;
        }

        public bool Create(AvailableTime availableTime)
        {
            int result;
            result = _availableTimeRepository.Create(availableTime);
            if (result == 1)
                return true;
            else
                return false;
        }

        public bool Delete(int id)
        {
            int result;
            result = _availableTimeRepository.Delete(id);
            if (result == 1)
                return true;
            else
                return false;
        }

        public List<AvailableTime> GetAll()
        {
            return _availableTimeRepository.GetAll();
        }

        public AvailableTime GetById(int id)
        {
            return _availableTimeRepository.GetById(id);
        }
        public List<AvailableTime> GetByTrainer(int id)
        {
            return _availableTimeRepository2.GetByTrainer(id);
        }

        public bool Update(AvailableTime availableTime)
        {

            int result;
            result = _availableTimeRepository.Update(availableTime);
            if (result == 1)
                return true;
            else
                return false;
        }

        public void updateStatusbyID(int id, int st)
        {
            _availableTimeRepository2.updateStatusbyID(id,st);
        }
    }
}
