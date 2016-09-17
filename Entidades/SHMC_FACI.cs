using System;
using System.Runtime.Serialization;

namespace Entidades
{
    [DataContract]
    public class SHMC_FACI
    {
        [DataMember]
        public int COD_FACI { get; set; }

        [DataMember]
        public string ALF_FACI { get; set; }
    }
}
