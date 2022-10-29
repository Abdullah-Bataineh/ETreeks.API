using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.INFRA.Service
{
    public class ReservationService:IService<Reservation>
    {
        private readonly IRepository<Reservation> _reservationRepository;
        public ReservationService(IRepository<Reservation> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public bool Create(Reservation reservation)
        {
            int result;
            result = _reservationRepository.Create(reservation);
            if (result == 1)

                return true;

            else return false;
        }

        public bool Delete(int id)
        {
            int result;
            result = _reservationRepository.Delete(id);
            if (result == 1)

                return true;

            else return false;
        }

        public List<Reservation> GetAll()
        {
            return _reservationRepository.GetAll();
        }

        public Reservation GetById(int id)
        {
            return _reservationRepository.GetById(id);
        }

        public bool Update(Reservation reservation)
        {
            int result;
            result = _reservationRepository.Update(reservation);
            if (result == 1)
                return true;
            else
                return false;
        }
    }
}
