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
        //public Reservation GetByCustomer(Customer customer)
        //{
        //    IReservationRepository instance = new ReservationRepository();
        //    return instance.GetByCustomer(customer);
        //}



        public Reservation InsertReservation(Reservation reservation)
        {
            IReservationRepository instance = new ReservationRepository();
            return instance.InsertReservation(reservation);
        }

        public List<Reservation> GetAllReservations()
        {
            IReservationRepository instance = new ReservationRepository();
            return instance.GetAllReservations();
        }

        public Reservation UpdateReservation(Reservation reservation)
        {

            IReservationRepository instance = new ReservationRepository();
            return instance.UpdateReservation(reservation);
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Reservation DeleteReservation (Reservation reservation)
        {
            IReservationRepository instance = new ReservationRepository();
            return instance.DeleteReservation(reservation);
        }
    }
}