using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{   
   
    public interface IReservationRepository
    {
        //Reservation GetByCustomer(Customer customer);
        Reservation InsertReservation(Reservation reservation);
        List<Reservation> GetAllReservations();
        Reservation UpdateReservation(Reservation reservation);
        Reservation DeleteReservation(Reservation reservation);
    }
}
