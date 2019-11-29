using Interface;
using Model;
using SQLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class TableController : IDisposable
    {
        public Table InsertTable (Table table)
        {
            ITableRepository instance = new TableRepository();
            return instance.InsertTable(table);
        }

        public List <Table> GetTablesBySeats(int seats)
        {
            ITable instance = new TableRepository();
            return instance.GetTablesBySeats(seats);
        }

        public List<Table> GetTablesByOrder(Order order)
        {
            ITableRepository instance = new TableRepository();
            return instance.GetTablesByOrder(order);
        }


        public List<Table> GetAllTables()
        {
            ITableRepository instance = new TableRepository();
            return instance.GetAllTables();
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
