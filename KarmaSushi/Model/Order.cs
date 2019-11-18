using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using ServiceKarma.Model;

namespace Model
{
    [DataContract]
    public class Order
    {
        /// <summary>
        /// Unique Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Time when the order was created.
        /// Persistent database handles creation.
        /// </summary>
        [DataMember]
        public DateTime Time { get; set; }

        /// <summary>
        /// Customer who placed order.
        /// </summary>
        [DataMember]
        public Customer Customer { get; set; }

        /// <summary>
        /// Table at which the order was placed.
        /// </summary>
        [DataMember]
        public Table Table { get; set; }

        /// <summary>
        /// Employee who placed the order for the customer.
        /// </summary>
        [DataMember]
        public Employee Employee { get; set; }

        /// <summary>
        /// List of order lines containing one product and the quantity of that product.
        /// </summary>
        [DataMember]
        public List<OrderLine> OrderLines { get; set; }

        #region Dapper test

        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }

        #endregion
    }
}