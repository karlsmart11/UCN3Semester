﻿using Controller;
using Model;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class TableService : ITableServices
    {
        public Table InsertTable(Table table)
        {
            try
            {
                using (var instance = new TableController())
                {
                    return instance.InsertTable(table);
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

        public List<Table> GetTablesByOrder(Order order)
        {
            try
            {
                using (var instance = new TableController())
                {
                    return instance.GetTablesByOrder(order);
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

        public List<Table> GetAllTables()
        {
            try
            {
                using (var instance = new TableController())
                {
                    return instance.GetAllTables();
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
    
