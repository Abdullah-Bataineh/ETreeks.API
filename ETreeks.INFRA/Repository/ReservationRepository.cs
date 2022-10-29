using Dapper;
using ETreeks.CORE.Common;
using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace ETreeks.INFRA.Repository
{
    public class ReservationRepository : IRepository<Reservation>
    {
        private readonly IDbContext _dbContext;
        public ReservationRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Reservation reservation)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("STARTDATE", reservation.StartDate, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ENDDATE", reservation.EndDate, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RES_STATUS", reservation.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("USERID", reservation.UserId, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("TR_CO_ID", reservation.TrainerCourseId, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("RESERVATION_PACKAGE.CREATERESERVATION", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }

        public int Delete(int id)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("RESERVATIONID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("RESERVATION_PACKAGE.DELETERESERVATION", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }

        public List<Reservation> GetAll()
        {
            IEnumerable<Reservation> result = _dbContext.Connection.Query<Reservation>("RESERVATION_PACKAGE.GETALLRESERVATION", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Reservation GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("RESERVATIONID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Reservation> result = _dbContext.Connection.Query<Reservation>("RESERVATION_PACKAGE.GETRESERVATIONBYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public int Update(Reservation reservation)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("RESERVATIONID", reservation.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("STARTDATE", reservation.StartDate, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ENDDATE", reservation.EndDate, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RES_STATUS", reservation.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("USERID", reservation.UserId, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("TR_CO_ID", reservation.TrainerCourseId, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("RESERVATION_PACKAGE.UPDATERESERVATION", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }
    }
}
