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
    public class TrainerRepository : IRepository<Trainer>
    {
        private readonly IDbContext _dbContext;
        public TrainerRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Trainer trainer)
        {
            int result; 
            var p = new DynamicParameters();
            p.Add("CERTIFICATE", trainer.Certificate, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LOCATION", trainer.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CV", trainer.Cv, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("STATUS", trainer.Status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("USER_ID", trainer.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CAT_ID", trainer.CatId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("TRAINER_PACKAGE.CREATETRAINER", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }

        public int Delete(int id)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("TRAINERID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("TRAINER_PACKAGE.DELETETRAINER", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }


        List<Trainer> IRepository<Trainer>.GetAll()
        {
            IEnumerable<Trainer> result = _dbContext.Connection.Query<Trainer>("TRAINER_PACKAGE.GETALLTRAINER", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }




        public Trainer GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("TRAINERID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Trainer> result = _dbContext.Connection.Query<Trainer>("TRAINER_PACKAGE.GETTRAINERBYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public int Update(Trainer trainer)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("TRAINERID", trainer.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CERTIFICATE", trainer.Certificate, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LOCATION", trainer.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CV", trainer.Cv, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("STATUS", trainer.Status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("USER_ID", trainer.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CAT_ID", trainer.CatId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("TRAINER_PACKAGE.UPDATETRAINER", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }

      
       
    }
}
