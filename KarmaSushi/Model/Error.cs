using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    
        [DataContract]
        public class Error
        {
            [DataMember]
            public string CodigoError { get; set; }
            [DataMember]
            public string Mensaje { get; set; }
            [DataMember]
            public string Description { get; set; }
        }
    }

