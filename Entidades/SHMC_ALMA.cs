using System;
using System.Runtime.Serialization;

namespace Entidades
{
    [DataContract]
    public class SHMC_ALMA
    {
        [DataMember]
        public int COD_ALMA { get; set; }

        [DataMember]
        public string ALF_ALMA { get; set; }
    }
}
