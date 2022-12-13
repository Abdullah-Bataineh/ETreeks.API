using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.INFRA.Service
{
    public class ReviewService: IReviewService
    {
        private readonly IReviewRepository _repository;

        public ReviewService(IReviewRepository repository)
        {
            
            _repository = repository;
        }

        public void createReview(Review review)
        {
            _repository.createReview(review);
        }

        public Review GetReviewByReservation(int r_id)
        {
            return _repository.GetReviewByReservation(r_id);
        }
    }
}
