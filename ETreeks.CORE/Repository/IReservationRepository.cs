using ETreeks.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Repository
{
    public interface IReservationRepository
    {
        public List<search> Search(search search);

        public List<ReservationAccept> GetReservation(int t_id);
        public List<ReservationAccept> GetReservationByUser(int u_id);
        public List<UserByCourse> GetUserOfEachCourse(int t_id);
    }
}
