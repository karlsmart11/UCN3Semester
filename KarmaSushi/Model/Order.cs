using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

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
        /// Summed price of all products bought in the order.
        /// </summary>
        public decimal Price { get; set; }

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
        /// List of tables associated with the order.
        /// </summary>
        [DataMember]
        public List<Table> Tables { get; set; }

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