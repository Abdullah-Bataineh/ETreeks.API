using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using ETreeks.INFRA.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.INFRA.Service
{
    public class LoginService : IService<Login>
    {
        private readonly IRepository<Login> _loginRepository;
        public LoginService(IRepository<Login> loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public bool Create(Login login)
        {
            int result;
            result = _loginRepository.Create(login);
            if (result == 1)
                return true;
            else
                return false;
        }

        public bool Delete(int id)
        {
            int result;
            result = _loginRepository.Delete(id);
            if (result == 1)
                return true;
            else
                return false;
        }

        public List<Login> GetAll()
        {
            return _loginRepository.GetAll();
        }

        public Login GetById(int id)
        {
            return _loginRepository.GetById(id);
        }

        public bool Update(Login login)
        {
            int result;
            result = _loginRepository.Update(login);
            if (result == 1)
                return true;
            else
                return false;
        }
    }
}
