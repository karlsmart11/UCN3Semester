using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Model
{   
    [DataContract]
    public class Table
    {
        /// <summary>
        /// Id of the table from the db.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Name of the table, eg. Table 1 or Table by the window.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        #region Dapper test

        public int OrderId { get; set; }

        #endregion
    }
}