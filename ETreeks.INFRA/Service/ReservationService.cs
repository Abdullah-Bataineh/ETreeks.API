using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.INFRA.Service
{
    public class ReservationService : IService<Reservation> , IReservationService
    {
        private readonly IReservationRepository _reservationRepository1;
        
        private readonly IRepository<Reservation> _reservationRepository;
        public ReservationService(IRepository<Reservation> reservationRepository, IReservationRepository reservationRepository1)
        {
            _reservationRepository = reservationRepository;
            _reservationRepository1 = reservationRepository1;
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
        public List<search> Search(search search)
        {
            return _reservationRepository1.Search(search);
        }
    }
}
