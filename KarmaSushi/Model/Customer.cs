using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Model
{    [DataContract]
    public class Customer
    {
        /// <summary>
        /// Id of the customer from the db.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Name of the customer.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// The customers phone number.
        /// </summary>
        [DataMember]
        public string Phone { get; set; }

        /// <summary>
        /// The customers email.
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Address { get; set; }
        /// <summary>
        /// Version of the row to optimistic handling of concurrency.
        /// </summary>
        [DataMember]
        public byte[] RowVer { get; set; }
    }
}