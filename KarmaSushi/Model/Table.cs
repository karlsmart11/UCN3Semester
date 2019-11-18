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
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        #region Dapper test

        public int OrderId { get; set; }

        #endregion
    }
}