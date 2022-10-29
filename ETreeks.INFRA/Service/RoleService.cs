using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using ETreeks.INFRA.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.INFRA.Service
{
    public class RoleService : IService<Role>
    {
        private readonly IRepository<Role> _roleRepository;
        public RoleService(IRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public bool Create(Role role)
        {
            int result;
            result =  _roleRepository.Create(role);
            if (result == 1)
                return true;
            else
                return false;
        }

        public bool Delete(int id)
        {
            int result;
            result = _roleRepository.Delete(id);
            if (result == 1)
                return true;
            else
                return false;
        }

        public List<Role> GetAll()
        {
            return _roleRepository.GetAll();
        }

        public Role GetById(int id)
        {
            return _roleRepository.GetById(id);
        }

        public bool Update(Role role)
        {
            int result;
            result = _roleRepository.Update(role);
            if (result ==1 )
                return true;
            else
                return false ;
        }
    }
}
