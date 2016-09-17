using System;
using System.Runtime.Serialization;

namespace Entidades
{
    [DataContract]
    public class SHMC_USUA
    {
        [DataMember]
        public string COD_USUA { get; set; }

        [DataMember]
        public int COD_TECN { get; set; }

        [DataMember]
        public string ALF_PASS { get; set; }

        [DataMember]
        public string ALF_TELE { get; set; }

        [DataMember]
        public bool IND_INST { get; set; }

        [DataMember]
        public int NUM_TOKE { get; set; }
    }
}
