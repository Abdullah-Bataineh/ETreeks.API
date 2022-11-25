using Dapper;
using ETreeks.CORE.Common;
using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using ETreeks.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ETreeks.INFRA.Repository
{
    public class UserRepository:IRepository<User>,IUserRepository
    {
        private readonly IDbContext _dbContext;
        public UserRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<KeyValuePair<string, int>> CreateUser(UserLogin userlogin)
        {
            int user_id;
            var p = new DynamicParameters();
            p.Add("FIRSTNAME", userlogin.First_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LASTNAME", userlogin.Last_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("BIRTHDATE", userlogin.Birth_Date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("PHONENUMBER", userlogin.Phone_Number, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGEUSER", userlogin.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("USERS_PACKAGE.CREATEUSERS", p, commandType: CommandType.StoredProcedure);
            user_id = p.Get<int>("RES");

            int login_id;
            Random VerfiyCode = new Random();
            int _VerfiyCode = VerfiyCode.Next(1000, 9999);
            var p1 = new DynamicParameters();
            p1.Add("EMAILLOGIN", userlogin.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p1.Add("PASSWORDLOGIN", userlogin.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p1.Add("CODE", _VerfiyCode, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p1.Add("ROLEID", userlogin.Role_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p1.Add("USERID", user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p1.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p1.Add("LOGIN_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("LOGIN_PACKAGE.CREATELOGIN", p1, commandType: CommandType.StoredProcedure); login_id = p1.Get<int>("LOGIN_ID");
            

            var myList = new List<KeyValuePair<string, int>>();

            // adding elements
            myList.Add(new KeyValuePair<string, int>("login_id", login_id));
            myList.Add(new KeyValuePair<string, int>("user_id", user_id));


            return myList;
        }

        public int Delete(int id)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("USERID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("USERS_PACKAGE.DELETEUSERS", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }

        public List<User> GetAll()
        {
            IEnumerable<User> result = _dbContext.Connection.Query<User>("USERS_PACKAGE.GETALLUSERS", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public User GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("USERID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<User> result = _dbContext.Connection.Query<User>("USERS_PACKAGE.GETUSERSBYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public int Update(User user)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("USERID", user.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("FIRSTNAME", user.First_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LASTNAME", user.Last_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("BIRTHDATE", user.Birth_Date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("PHONENUMBER", user.Phone_Number, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGEUSER", user.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("USERS_PACKAGE.UPDATEUSERS", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }
        public List<User> Search(string c_name)
        {
            var p = new DynamicParameters();
            p.Add("u_name", c_name, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<User> result = _dbContext.Connection.Query<User>("USERS_PACKAGE.SEARCHUSERS", p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public int Create(User t)
        {
            throw new NotImplementedException();
        }
    }
}
