using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.INFRA.Service
{
    public class UserService:IService<User>
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
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

        public bool Update(User user)
        {
            int result;
            result = _repository.Update(user);
            if (result == 1)
                return true;
            else
                return false;
        }
    }
}
