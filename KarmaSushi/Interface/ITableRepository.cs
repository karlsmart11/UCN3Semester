using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface ITableRepository
    {
        Table InsertTable(Table table);

        List<Table> GetTablesBySeats(int seats);
        List<Table> GetTablesByOrder(Order order);
        List<Table> GetAllTables();
        List<Table> GetAvailableTables(string desiredTime);
        void ModifyTable(Table table);
    }
}