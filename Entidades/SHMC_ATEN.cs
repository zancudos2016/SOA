using System;
using System.Runtime.Serialization;

namespace Entidades
{
    [DataContract]
    public class SHMC_ATEN
    {
        [DataMember]
        public int COD_ATEN { get; set; }

        [DataMember]
        public int COD_PUNT_ATEN { get; set; }

        [DataMember]
        public int COD_TIPO { get; set; }

        [DataMember]
        public DateTime FEC_ATEN { get; set; }

        [DataMember]
        public string ALF_COME { get; set; }

        [DataMember]
        public DateTime FEC_PROG { get; set; }

        [DataMember]
        public int COD_TECN { get; set; }

        [DataMember]
        public int COD_ESTA { get; set; }
    }
}
