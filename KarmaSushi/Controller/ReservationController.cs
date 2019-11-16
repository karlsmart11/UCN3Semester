using Contract;
using Model;
using ServiceKarma.Model;
using SQLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceKarma.Controller
{
    public class ReservationController : IDisposable
    {
        public Reservation GetByCustomer(Customer customer)
        {
            IReservation instance = new ReservationRepository();
            return GetByCustomer(customer);
        }



        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}