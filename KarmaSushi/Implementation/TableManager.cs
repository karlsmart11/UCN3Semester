using Controller;
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
    public class TableManager : ITableServices
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
        public List<Table> GetTablesBySeats(int seats)
        {
            try
            {
                using (var instance = new TableController())
                {
                    return instance.GetTablesBySeats(seats);
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

        public List<Table> GetAvailableTables(string desiredTime)
        {
            try
            {
                using (var instance = new TableController())
                {
                    return instance.GetAvailableTables(desiredTime);
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

        public void ModifyTable(Table table)
        {
            try
            {
                using (var instance = new TableController())
                {
                    instance.ModifyTable(table);
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
    
