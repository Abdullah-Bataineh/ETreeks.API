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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext _dbContext;
        public CategoryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //sadfsfdg;flsdm
        //fgdddd
        //ddddddddddddddddddddddddddddddddd
        public int CreateCategory(Category category)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("NAME", category.CategoryName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("CATEGORY_PACKAGE.CREATECATEGORY", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }

        public int DeleteCategory(int id)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("CATEGORYID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("CATEGORY_PACKAGE.DELETECATEGORY", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }

        public List<Category> GetAllCategories()
        {
            IEnumerable<Category> result = _dbContext.Connection.Query<Category>("CATEGORY_PACKAGE.GETALLCATEGORIES", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Category GetCategoryById(int id)
        {
            var p = new DynamicParameters();
            p.Add("CATEGORYID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Category> result = _dbContext.Connection.Query<Category>("CATEGORY_PACKAGE.GETCATEGORYBYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public int UpdateCategory(Category category)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("NAME", category.CategoryName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CATEGORYID", category.Id, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("CATEGORY_PACKAGE.CREATECATEGORY", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }
    }
}
