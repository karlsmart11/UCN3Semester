using Model;
using ServiceKarma.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IReservation
    {
        public Reservation GetByCustomer(Customer customer);
    }
}
