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
    public class AvailableTimeRepsitory : IRepository<AvailableTime> ,IAvailableTimeRepository
    {
        private readonly IDbContext _dbContext;
        public AvailableTimeRepsitory(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(AvailableTime availableTime)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("START_D", availableTime.Start_Date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("STATUS_A", availableTime.STATUS, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("END_D", availableTime.End_Date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("TR_ID", availableTime.Trainer_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("AVAILABLETIME_PACKAGE.CREATETIME", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }

        public int Delete(int id)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("TIMEID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("AVAILABLETIME_PACKAGE.DELETETIME", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }


        List<AvailableTime> IRepository<AvailableTime>.GetAll()
        {
            IEnumerable<AvailableTime> result = _dbContext.Connection.Query<AvailableTime>("AVAILABLETIME_PACKAGE.GETALLTIMES", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }



        public int Update(AvailableTime availableTime)
        {

            int result;
            var p = new DynamicParameters();
            p.Add("TIMEID", availableTime.Id, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("STATUS_A", availableTime.STATUS, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("START_D", availableTime.Start_Date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("END_D", availableTime.End_Date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("TR_ID", availableTime.Trainer_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("AVAILABLETIME_PACKAGE.CREATETIME", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }

        public AvailableTime GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("TIMEID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<AvailableTime> result = _dbContext.Connection.Query<AvailableTime>("AVAILABLETIME_PACKAGE.GETTIMEBYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<AvailableTime> GetByTrainer(int trainerId)
        {
            var p = new DynamicParameters();
            p.Add("U_ID", trainerId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<AvailableTime> result = _dbContext.Connection.Query<AvailableTime>("AVAILABLETIME_PACKAGE.GETALLTIMESBYTRAINER", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
