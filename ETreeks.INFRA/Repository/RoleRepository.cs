using Dapper;
using ETreeks.CORE.Common;
using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ETreeks.INFRA.Repository
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly IDbContext _dbContext;
        public RoleRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Role role)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("NAME", role.RoleName, dbType: DbType.String, direction: ParameterDirection.Input);         
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("ROLE_PACKAGE.CREATEROLE", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }

        public int Delete(int id)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("ROLEID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("ROLE_PACKAGE.DELETEROLE", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }

        List<Role> IRepository<Role>.GetAll()
        {
            IEnumerable<Role> result = _dbContext.Connection.Query<Role>("ROLE_PACKAGE.GETALLROLE", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Role GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ROLEID", id, dbType: DbType.Int32, direction:ParameterDirection.Input);
            IEnumerable<Role> result = _dbContext.Connection.Query<Role>("ROLE_PACKAGE.GETROLEBYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public int Update(Role role)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("ROLEID", role.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("NAME", role.RoleName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RES" , dbType:DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("ROLE_PACKAGE.UPDATEROLE", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }
    }
}
