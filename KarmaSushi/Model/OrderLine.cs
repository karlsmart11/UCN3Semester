using System.Runtime.Serialization;

namespace Model
{   
    [DataContract]
    public class OrderLine
    {
        /// <summary>
        /// Id of the order line from the db.
        /// </summary>
        [DataMember]
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
        public int OrderId { get; set; }

        #endregion
    }
}