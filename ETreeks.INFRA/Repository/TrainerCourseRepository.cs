using Dapper;
using ETreeks.CORE.Common;
using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using ETreeks.CORE.Repository;
using ETreeks.INFRA.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ETreeks.INFRA.Repository
{
    public class TrainerCourseRepository : IRepository<TrainerCourse>,ITrainerCourseRepository

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
      public   List<Course> GetTrainerCourseByUserId(int id)
        {
            var p=new DynamicParameters();
            p.Add("U_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Course> result = _dbContext.Connection.Query<Course>("TRAINERCOURSE_PACKAGE.GETALLTRAINERCOURSE",p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<TrainerUser> GetTrainerByCourseId(int id)
        {
            var p = new DynamicParameters();
            p.Add("C_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<TrainerUser> result = _dbContext.Connection.Query<TrainerUser>("TRAINERCOURSE_PACKAGE.GETTRAINERBYCOURSEID", p, commandType: CommandType.StoredProcedure);
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
        public TrainerCourse GetIdTrainerCourse(int c_id,int t_id)
        {
            var p = new DynamicParameters();
            p.Add("C_ID", c_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("T_ID", t_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<TrainerCourse> result = _dbContext.Connection.Query<TrainerCourse>("TRAINERCOURSE_PACKAGE.GETTRAINERBYCOURSEIDANDTRAINERID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
