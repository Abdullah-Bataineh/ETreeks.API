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
    public class ContactInfoRepository:IRepository<ContactInfo>
    {
        private readonly IDbContext _dbContext;
        public ContactInfoRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(ContactInfo contactInfo)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("PHONE", contactInfo.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("WEBSITE", contactInfo.WebsiteName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LOCATN", contactInfo.Location, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("CONTACTINFO_PACKAGE.CREATECONTACTINFO", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }

      

        public int Delete(int id)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("CONTACTINFOID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("CONTACTINFO_PACKAGE.DELETECONTACTINFO", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }

        public List<ContactInfo> GetAll()
        {
            IEnumerable<ContactInfo> result = _dbContext.Connection.Query<ContactInfo>("CONTACTINFO_PACKAGE.GETCONTACTINFO", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public ContactInfo GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<ContactInfo> result = _dbContext.Connection.Query<ContactInfo>("CONTACTINFO_PACKAGE.GETCONTACTINFOBYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public int Update(ContactInfo contactInfo)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("CONTACTINFOID", contactInfo.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("PHONE", contactInfo.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("WEBSITE", contactInfo.WebsiteName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LOCATN", contactInfo.Location, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);

           
            _dbContext.Connection.Execute("CONTACTINFO_PACKAGE.UPDATECONTACTINFO", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }

   

        
    }
}
