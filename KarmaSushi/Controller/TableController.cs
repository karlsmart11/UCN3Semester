using Interface;
using Model;
using SQLRepository;
using System;
using System.Collections.Generic;

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
            ITableRepository instance = new TableRepository();
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
        public List<Table> GetAvailableTables(string DesiredTime)
        {
            ITableRepository instance = new TableRepository();
            return instance.GetAvailableTables(DesiredTime);
        }
        public void ModifyTable(Table table)
        {
            ITableRepository instance = new TableRepository();
            instance.ModifyTable(table);
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
