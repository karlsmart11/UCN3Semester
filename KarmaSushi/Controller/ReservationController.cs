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



        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}