﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiceKarma.Model
{   [DataContract]
    public class Product
    {   [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public Category Category { get; set; }
    }

    //[DataContract] ?
    public enum Category { Appetizer, MainCourse, Dessert };
}