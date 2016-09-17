using System;
using System.Runtime.Serialization;

namespace Entidades
{
    [DataContract]
    public class SHMC_EMPL
    {
        [DataMember]
        public int COD_TECN { get; set; }

        [DataMember]
        public string ALF_EMPL { get; set; }
    }
}
