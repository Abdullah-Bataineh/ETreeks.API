using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.INFRA.Service
{
    public class ContactUsService : IService<ContactU>
    {
        private readonly IRepository<ContactU> _contactUsRepository;
        public ContactUsService(IRepository<ContactU> contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        public bool Create(ContactU contactU)
        {
            int result;
            result = _contactUsRepository.Create(contactU);
            if (result == 1)
            
                return true;
            
            else return false;
        }

        public bool Delete(int id)
        {
            int result;
            result = _contactUsRepository.Delete(id);
            if (result == 1)
            
                return true;
            
            else return false;
        }

        public List<ContactU> GetAll()
        {
            return _contactUsRepository.GetAll();
        }

        public ContactU GetById(int id)
        {
            return _contactUsRepository.GetById(id);
        }

        public bool Update(ContactU contactU)
        {
           int result;
            result = _contactUsRepository.Update(contactU);
            if (result == 1)
                return true;
            else
                return false;
        }
    }
}
