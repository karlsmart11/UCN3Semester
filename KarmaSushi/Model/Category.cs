using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Category
    {
        /// <summary>
        /// Id of the category from the db.
        /// </summary>
        [DataMember]
        public int Id { get; set; }
        /// <summary>
        /// Name of the category, eg. Roll or Nigiri.
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// Version of the row to optimistic handling of concurrency.
        /// </summary>
        [DataMember]
        public byte[] RowVer { get; set; }
    }
}
