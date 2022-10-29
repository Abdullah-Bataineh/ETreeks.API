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
    public class CourseRepository : IRepository<Course>
    {
        private readonly IDbContext _dbContext;
        public CourseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Course course)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("NAME", course.COURSE_NAME, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("DESCRIPTION",course.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CAT_ID", course.CatId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("COURSE_PACKAGE.CREATECOURSE", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }

        public int Delete(int id)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("COURSE_PACKAGE.DELETECOURSE", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }

        public List<Course> GetAll()
        {
            IEnumerable<Course> result = _dbContext.Connection.Query<Course>("COURSE_PACKAGE.GETALLCOURSES", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Course GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Course> result = _dbContext.Connection.Query<Course>("COURSE_PACKAGE.GETCOURSEBYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public int Update(Course course)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("ID", course.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("NAME", course.COURSE_NAME, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CAT_ID", course.CatId, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("DESCRIPTION", course.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("COURSE_PACKAGE.UPDATECOURSE", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }
    }
}
