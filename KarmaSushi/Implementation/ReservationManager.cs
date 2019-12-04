using System;
using ServiceContract;
using Model;
using Controller;
using System.ServiceModel;
using System.Collections.Generic;

namespace Implementation
{
    public class ReservationManager : IReservationServices
    {
        //public Reservation GetByCustomer(Customer customer)
        //{
        //    try
        //    {
        //        using (var instance = new ReservationController())
        //        {
        //            return instance.GetByCustomer(customer);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new FaultException<Error>(new Error()
        //        {
        //            CodigoError = "10001",
        //            Mensaje = ex.Message,
        //            Description = "Exception managed by the administrator"
        //        });
        //    }
        //}
        public Reservation InsertReservation(Reservation reservation)
        {
            try
            {
                using (var instance = new ReservationController())
                {
                    return instance.InsertReservation(reservation);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error()
                {
                    CodigoError = "10001",
                    Mensaje = ex.Message,
                    Description = "Exception managed by the administrator"
                });
            }
        }

        public List<Reservation> GetAllReservations()
        {
            try
            {
                using (var instance = new ReservationController())
                {
                    return instance.GetAllReservations();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error()
                {
                    CodigoError = "10001",
                    Mensaje = ex.Message,
                    Description = "Exception managed by the administrator"
                });
            }
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            try
            {
                using (var instance = new ReservationController())
                {
                    return instance.UpdateReservation(reservation);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error()
                {
                    CodigoError = "10001",
                    Mensaje = ex.Message,
                    Description = "Exception managed by the administrator"
                });
            }
        }

        public Reservation DeleteReservation(Reservation reservation)
        {
            try
            {
                using (var instance = new ReservationController())
                {
                    return instance.DeleteReservation(reservation);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error()
                {
                    CodigoError = "10001",
                    Mensaje = ex.Message,
                    Description = "Exception managed by the administrator"
                });
            }
        }


    }
}
