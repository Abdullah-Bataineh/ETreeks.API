using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using ETreeks.INFRA.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.INFRA.Service
{
    public class HomeService : IService<HomePage>
    {
        private readonly IRepository<HomePage> _homerepository;

        public HomeService(IRepository<HomePage> homerepository)
        {
            _homerepository = homerepository;
        }
        public bool Create(HomePage home)
        {
            int result;
            result = _homerepository.Create(home);
            if (result == 1)
                return true;
            else
                return false;
        }

        public bool Delete(int id)
        {
            int result;
            result = _homerepository.Delete(id);
            if (result == 1)
                return true;
            else
                return false;
        }

        public List<HomePage> GetAll()
        {
            return _homerepository.GetAll();
        }

        public HomePage GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(HomePage home)
        {
            int result;
            result = _homerepository.Update(home);
            if (result == 1)
                return true;
            else
                return false;
        }
    }
}
