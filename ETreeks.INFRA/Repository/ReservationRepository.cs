using Dapper;
using ETreeks.CORE.Common;
using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using ETreeks.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace ETreeks.INFRA.Repository
{
    public class ReservationRepository : IRepository<Reservation> ,IReservationRepository
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
            p.Add("RES_STATUS", reservation.Status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("USERID", reservation.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TR_CO_ID", reservation.Trainer_Course_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("AVAILABLE_ID", reservation.avaliable_time_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("RESERVATION_PACKAGE.CREATERESERVATION", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }
        //moh

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
            p.Add("AVAILABLE_ID", reservation.avaliable_time_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RES_STATUS", reservation.Status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("USERID", reservation.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TR_CO_ID", reservation.Trainer_Course_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("RESERVATION_PACKAGE.UPDATERESERVATION", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }
        public List<search> Search(search search)
        {
            var p = new DynamicParameters();
            p.Add("TR_ID", search.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("COURSENAME", search.COURSE_NAME, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("STARTDATE", search.Start_Date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("ENDDATE", search.End_Date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<search>("RESERVATION_PACKAGE.SEARCH", p, commandType: CommandType.StoredProcedure);   
            return result.ToList();

        }
        public List<ReservationAccept> GetReservation(int t_id)
        {
            var p = new DynamicParameters();
            p.Add("t_id", t_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<ReservationAccept> result = _dbContext.Connection.Query<ReservationAccept>("RESERVATION_PACKAGE.GETRESERVATION", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<ReservationAccept> GetReservationByUser(int u_id)
        {
            var p = new DynamicParameters();
            p.Add("u_id", u_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<ReservationAccept> result = _dbContext.Connection.Query<ReservationAccept>("RESERVATION_PACKAGE.GETRESERVATIONBYUSER", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
