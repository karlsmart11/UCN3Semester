using Model;
using System.Collections.Generic;

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