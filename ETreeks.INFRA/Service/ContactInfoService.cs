using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.INFRA.Service
{
    public class ContactInfoService : IService<ContactInfo>
    {
        private readonly IRepository<ContactInfo> _repository;
        public ContactInfoService(IRepository<ContactInfo> repository)
        {
            _repository = repository;
        }
        public bool Create(ContactInfo contactInfo)
        {
            int result;
            result = _repository.Create(contactInfo);
            if (result == 1)
                return true;
            else
                return false;
        }

        public bool Delete(int id)
        {
            int result;
            result = _repository.Delete(id);
            if (result == 1)
                return true;
            else
                return false;
        }

        public List<ContactInfo> GetAll()
        {
            return _repository.GetAll();
        }

        public ContactInfo GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Update(ContactInfo contactInfo)
        {
            int result;
            result = _repository.Update(contactInfo);
            if (result == 1)
                return true;
            else
                return false;
        }
    }
}
