using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface ITable
    {
        Table InsertTable(Table table);
        List<Table> GetTablesByOrder(Order order);
        List<Table> GetAllTables();
    }
}