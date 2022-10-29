using Dapper;
using ETreeks.CORE.Common;
using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ETreeks.INFRA.Repository
{//abdullah
    public class TestimonialRepository : IRepository<Testimonial>
    {
        private readonly IDbContext _dbContext;
        public TestimonialRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(Testimonial testimonial)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("TEST_TEXT", testimonial.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("TEST_STATUS", testimonial.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("USERID", testimonial.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("TESTIMONIAL_PACKAGE.CREATETESTIMONIAL", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }

        public int Delete(int id)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("TESTIMONIALID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("TESTIMONIAL_PACKAGE.DELETETESTIMONIAL", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }

        public List<Testimonial> GetAll()
        {
            IEnumerable<Testimonial> result = _dbContext.Connection.Query<Testimonial>("TESTIMONIAL_PACKAGE.GETALLTESTIMONIAL", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Testimonial GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("TESTIMONIALID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Testimonial> result = _dbContext.Connection.Query<Testimonial>("TESTIMONIAL_PACKAGE.GETTESTIMONIALBYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public int Update(Testimonial testimonial)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("TESTIMONIALID", testimonial.Text, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TEST_TEXT", testimonial.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("TEST_STATUS", testimonial.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("USERID", testimonial.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("TESTIMONIAL_PACKAGE.UPDATETESTIMONIAL", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }
    }
}
