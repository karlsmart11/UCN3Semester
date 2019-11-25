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
            ITable instance = new TableRepository();
            return instance.InsertTable(table);
        }

        public List<Table> GetTablesByOrder(Order order)
        {
            ITable instance = new TableRepository();
            return instance.GetTablesByOrder(order);
        }

        public List<Table> GetAllTables()
        {
            ITable instance = new TableRepository();
            return instance.GetAllTables();
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
