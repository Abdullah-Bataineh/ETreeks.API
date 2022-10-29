using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.INFRA.Service
{
    public class AboutService : IService<About>
    {
        private readonly IRepository<About> _aboutRepository;

        public AboutService(IRepository<About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public bool Create(About about)
        {
            int result;
            result = _aboutRepository.Create(about);
            if (result == 1)
                return true;
            else
                return false;
        }

        public bool Delete(int id)
        {
            int result;
            result = _aboutRepository.Delete(id);
            if (result == 1)
                return true;
            else
                return false;
        }

        public List<About> GetAll()
        {
            return _aboutRepository.GetAll();
        }

        public About GetById(int id)
        {
            return _aboutRepository.GetById(id);
        }

        public bool Update(About about)
        {
            int result;
            result = _aboutRepository.Update(about);
            if (result == 1)
                return true;
            else
                return false;
        }
    }
}
