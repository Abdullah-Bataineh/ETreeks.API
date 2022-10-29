using Dapper;
using ETreeks.CORE.Common;
using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using ETreeks.INFRA.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ETreeks.INFRA.Repository
{
    public class TrainerCourseRepository : IRepository<TrainerCourse>
    {
        private readonly IDbContext _dbContext;

        public TrainerCourseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(TrainerCourse trainerCourse)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("COURSEID", trainerCourse.Course_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TRAINERID", trainerCourse.Trainer_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("TRAINERCOURSE_PACKAGE.CREATETRAINERCOURSE", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }

        public int Delete(int id)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("TRAINERCOURSEID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("TRAINERCOURSE_PACKAGE.DELETETRAINERCOURSE", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }

        List<TrainerCourse> IRepository<TrainerCourse>.GetAll()
        {
            IEnumerable<TrainerCourse> result = _dbContext.Connection.Query<TrainerCourse>("TRAINERCOURSE_PACKAGE.GETALLTRAINERCOURSE", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public TrainerCourse GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("TRAINERCOURSEID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<TrainerCourse> result = _dbContext.Connection.Query<TrainerCourse>("TRAINERCOURSE_PACKAGE.GETTRAINERCOURSEBYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public int Update(TrainerCourse trainerCourse)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("TRAINERCOURSEID", trainerCourse.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("COURSEID", trainerCourse.Course_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TRAINERID", trainerCourse.Trainer_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("TRAINERCOURSE_PACKAGE.UPDATETRAINERCOURSE", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }
    }
}
