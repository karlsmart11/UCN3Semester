using Model;
using SQLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interface;

namespace Controller
{
    public class ReservationController : IDisposable
    {
        public Reservation GetByCustomer(Customer customer)
        {
            IReservation instance = new ReservationRepository();
            return instance.GetByCustomer(customer);
        }

        public Reservation InsertReservation(Reservation reservation)
        {
            //TODO Handle already existing customer. Maybe by phone.
            IReservation instance = new ReservationRepository();
            return instance.InsertReservation(reservation);
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}