using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using ETreeks.INFRA.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace ETreeks.INFRA.Service
{
    public class LoginService : IService<Login>,IVerfiyAccountService,ILoginService
    {
        private readonly IRepository<Login> _loginRepository;
        private readonly IVerfiyAccountRepository _verfiyRepository;
        private readonly ILoginRepository _loginRepository1;

        public LoginService(IRepository<Login> loginRepository,IVerfiyAccountRepository verfiyAccountRepository,ILoginRepository loginRepository1)
        {
            _loginRepository = loginRepository;
            _verfiyRepository = verfiyAccountRepository;
              _loginRepository1 = loginRepository1;
            
        }

        public bool Create(Login login)
        {
            
            int result;
            result = _loginRepository.Create(login);
            if (result == 1)
            {
                
                return true;
            }
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

        public List<string> GetPhoneNumber(int id)
        {
            return _loginRepository1.GetPhoneNumber(id);
        }

        public void DELETEVERIFYCODE(int id)
        {
            _loginRepository1.DELETEVERIFYCODE(id); 
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

        public bool Verfiy( int code, int id)
        {
            int result;
            result = _verfiyRepository.Verfiy( code,id);
            if (result == 1)
                return true;
            else
                return false;
        }
        public int CreateLogIn(Login login)
        {
            return _loginRepository1.CreateLogIn(login);    
        }

        public Login GetByUserId(int userid)
        {
            return _loginRepository1.GetByUserId(userid);

        }
    }
}
