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
    public class AboutRepository : IRepository<About>
    {
        private readonly IDbContext _dbContext;
        public AboutRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(About about)
        {
            int result; 
            var p = new DynamicParameters();
            p.Add("TEXT", about.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("TITLE", about.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGE", about.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("ABOUT_PACKAGE.CREATEABOUT", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }

        public int Delete(int id)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("ABOUTID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("ABOUT_PACKAGE.DELETEABOUT", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }


        List<About> IRepository<About>.GetAll()
        {
            IEnumerable<About> result = _dbContext.Connection.Query<About>("ABOUT_PACKAGE.GETALLABOUT", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }



        public int Update(About about)
        {

            int result;
            var p = new DynamicParameters();
            p.Add("ABOUTID", about.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TEXT", about.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("TITLE", about.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGE", about.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("ABOUT_PACKAGE.UPDATEABOUT", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }

        public About GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
