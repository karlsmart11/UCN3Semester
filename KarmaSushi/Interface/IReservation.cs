﻿using Model;
using ServiceKarma.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IReservation
    {
        Reservation GetByCustomer(Customer customer);
    }
}
