using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Model
{
    [DataContract]
    public class Product
    {
        /// <summary>
        /// Id of the product from the db.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Name of the product.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Description of the product.
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Price of 1 unit of the product.
        /// </summary>
        [DataMember]
        public double Price { get; set; }

        /// <summary>
        /// Category of the product.
        /// Used to group the products together.
        /// Fx. Rolls.
        /// </summary>
        [DataMember]
        public Category Category { get; set; }
    }

    public enum Category { Appetizer, MainCourse, Dessert };
}