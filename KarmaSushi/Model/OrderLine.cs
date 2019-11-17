using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Model
{   
    [DataContract]
    public class OrderLine
    {
        public int Id { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        [DataMember]
        public Product Product { get; set; }

        /// <summary>
        /// The amount of a specific product to be added to an order.
        /// </summary>
        [DataMember]
        public int Quantity { get; set; }

        //[DataMember]
        //public double Price { get; set; }

        #region Dapper test

        public int ProductId { get; set; }

        #endregion
    }
}