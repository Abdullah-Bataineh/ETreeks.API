using ETreeks.CORE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Repository
{
    public interface IReviewRepository
    {
        public Review GetReviewByReservation(int r_id);
        public void createReview(Review review);
    }
}
