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
    public class CategoryRepository : IRepository<Category>
    {
        private readonly IDbContext _dbContext;
        public CategoryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Category category)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("NAME", category.CATEGORY_NAME, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("cat_image", category.CATEGORY_NAME, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("cat_desc", category.DESCRIPTION, dbType: DbType.String, direction: ParameterDirection.Input);
            
            p.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("CATEGORY_PACKAGE.CREATECATEGORY", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }

        public int Delete(int id)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("CATEGORYID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("CATEGORY_PACKAGE.DELETECATEGORY", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }

        public List<Category> GetAll()
        {
            IEnumerable<Category> result = _dbContext.Connection.Query<Category>("CATEGORY_PACKAGE.GETALLCATEGORIES", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Category GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("CATEGORYID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Category> result = _dbContext.Connection.Query<Category>("CATEGORY_PACKAGE.GETCATEGORYBYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public int Update(Category category)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("CATEGORYID", category.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("NAME", category.CATEGORY_NAME, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("cat_image", category.CATEGORY_NAME, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("cat_desc", category.DESCRIPTION, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("CATEGORY_PACKAGE.UPDATECATEGORY", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }
    }
}
