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
using ETreeks.CORE.DTO;

namespace ETreeks.INFRA.Repository
{
    public class ReviewRepository: IReviewRepository
    {
        private readonly IDbContext _dbContext;
        public ReviewRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Review GetReviewByReservation(int r_id)
        {
            var p = new DynamicParameters();
            p.Add("R_ID", r_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Review> result = _dbContext.Connection.Query<Review>("REVIEW_PACKAGE.GETREVIEWBYRESERVATIONID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public void createReview(Review review)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("REVIEW", review.review, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("R_ID", review.RESERVATION_ID, dbType: DbType.String, direction: ParameterDirection.Input);
           
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("REVIEW_PACKAGE.CREATEREVIEW", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            
        }
    }
}
