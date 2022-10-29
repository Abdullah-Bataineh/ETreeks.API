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
    public class HomeRepository : IRepository<HomePage>
    {
        private readonly IDbContext _dbContext;
        public HomeRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(HomePage home)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("TEXT", home.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("TITLE", home.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGE", home.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("HOME_PACKAGE.CREATEHOME", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }

        public int Delete(int id)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("HOMEID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("HOME_PACKAGE.DELETEHOME", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }

        public List<HomePage> GetAll()
        {
            IEnumerable<HomePage> result = _dbContext.Connection.Query<HomePage>("HOME_PACKAGE.GETHOME", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public HomePage GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(HomePage home)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("HOMEID", home.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TXT", home.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("TTL", home.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMG", home.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("HOME_PACKAGE.UPDATEHOME", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }
    }
}
