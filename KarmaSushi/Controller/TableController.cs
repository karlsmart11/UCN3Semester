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



        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
