using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Model
{   
    [DataContract]
    public class Reservation
    {
        /// <summary>
        /// Id of the reservation from the db.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Time of reservation.
        /// TODO Fix this comment, rethink how to note time for reservation
        /// </summary>
        [DataMember]
        public DateTime Time { get; set; }
        
        /// <summary>
        /// Table reserved for the reservation.
        /// TODO Should probably be a list of tables
        /// </summary>
        [DataMember]
        public List<Table> Tables { get; set; }
        
        /// <summary>
        /// Employee who placed the reservation.
        /// </summary>
        [DataMember]
        public Employee Employee { get; set; }

        /// <summary>
        /// Customer who ordered the reservation.
        /// </summary>
        [DataMember]
        public Customer Customer { get; set; }
    }
}