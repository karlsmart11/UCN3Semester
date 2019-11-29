using System.Runtime.Serialization;

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

        [DataMember]
        public int Seats { get; set; }

       

        #region Dapper test

        public int OrderId { get; set; }

        #endregion
    }
}