using Model;
using System.Collections.Generic;

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
