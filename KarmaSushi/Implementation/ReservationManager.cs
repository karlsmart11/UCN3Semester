using System;
using ServiceContract;
using Model;
using Controller;
using System.ServiceModel;

namespace Implementation
{
    public class ReservationService : IReservationServices
    {
        public Reservation GetByCustomer(Customer customer)
        {
            try
            {
                using (var instance = new ReservationController())
                {
                    return instance.GetByCustomer(customer);
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
