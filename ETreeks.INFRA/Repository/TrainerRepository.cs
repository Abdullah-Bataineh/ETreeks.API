﻿using Dapper;
using ETreeks.CORE.Common;
using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ETreeks.INFRA.Repository
{
    public class TrainerRepository : IRepository<Trainer>,ITrainerRepository
    {
        private readonly IDbContext _dbContext;
        public TrainerRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<KeyValuePair<string, int>> CreateTrainer(TrainerLogin trainerlogin)
        {
            int user_id;
            var p = new DynamicParameters();
            p.Add("FIRSTNAME", trainerlogin.First_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LASTNAME", trainerlogin.Last_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("BIRTHDATE", trainerlogin.Birth_Date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("PHONENUMBER", trainerlogin.Phone_Number, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGEUSER", trainerlogin.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("USERS_PACKAGE.CREATEUSERS", p, commandType: CommandType.StoredProcedure);
            user_id = p.Get<int>("RES");

            int login_id;
            Random VerfiyCode = new Random();
            int _VerfiyCode = VerfiyCode.Next(1000, 9999);
            var p1 = new DynamicParameters();
            p1.Add("EMAILLOGIN", trainerlogin.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p1.Add("PASSWORDLOGIN", trainerlogin.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p1.Add("CODE", _VerfiyCode, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p1.Add("ROLEID", trainerlogin.Role_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p1.Add("USERID", user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p1.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p1.Add("LOGIN_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("LOGIN_PACKAGE.CREATELOGIN", p1, commandType: CommandType.StoredProcedure); login_id = p1.Get<int>("LOGIN_ID");


            var myList = new List<KeyValuePair<string, int>>();

            // adding elements
            myList.Add(new KeyValuePair<string, int>("login_id", login_id));
            myList.Add(new KeyValuePair<string, int>("user_id", user_id));
            int result; 
            var p2 = new DynamicParameters();
            p2.Add("CERTIFICATE", trainerlogin.Certificate, dbType: DbType.String, direction: ParameterDirection.Input);
            p2.Add("LOCATION", trainerlogin.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p2.Add("CV", trainerlogin.Cv, dbType: DbType.String, direction: ParameterDirection.Input);
            p2.Add("STATUS", trainerlogin.Status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p2.Add("USER_ID", user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p2.Add("CAT_ID", trainerlogin.Cat_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p2.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("TRAINER_PACKAGE.CREATETRAINER", p2, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return myList;
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
            p.Add("USER_ID", trainer.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CAT_ID", trainer.Cat_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("TRAINER_PACKAGE.UPDATETRAINER", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }

        public int Create(Trainer t)
        {
            throw new NotImplementedException();
        }
    }
}
