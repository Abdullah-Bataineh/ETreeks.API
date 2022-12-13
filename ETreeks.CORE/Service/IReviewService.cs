using ETreeks.CORE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Service
{
    public interface IReviewService
    {
          public Review GetReviewByReservation(int r_id);
        public void createReview(Review review);
    }
}
