using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.INFRA.Service
{
    public class UserService:IService<User>,IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IUserRepository _userRepository;

        public UserService(IRepository<User> repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public bool Create(User user)
        {
            int result;
            result = _repository.Create(user);
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

        public List<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<User> Search(string c_name)
        {
           return _userRepository.Search(c_name);
        }

        public bool Update(User user)
        {
            int result;
            result = _repository.Update(user);
            if (result == 1)
                return true;
            else
                return false;
        }

        public List<KeyValuePair<string, int>> CreateUser(UserLogin userlogin)
        {
            return _userRepository.CreateUser(userlogin);    
        }

    }
}
