using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Employee
    {
        /// <summary>
        /// Unique Id for the employee
        /// </summary>
        [DataMember]
        public int Id { get; set; }
        /// <summary>
        /// Name of the employee
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// Email of the employee
        /// </summary>
        [DataMember]
        public string Email { get; set; }
        /// <summary>
        /// Phone number of the employee
        /// </summary>
        [DataMember]
        public string Phone { get; set; }
        /// <summary>
        /// Version of the row to optimistic handling of concurrency.
        /// </summary>
        [DataMember]
        public byte[] RowVer { get; set; }
    }
}