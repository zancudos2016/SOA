using System;
using System.Runtime.Serialization;

namespace Entidades
{
    [DataContract]
    public class SHMC_PUNT_ATEN
    {
        [DataMember]
        public int COD_PUNT_ATEN { get; set; }

        [DataMember]
        public string ALF_NOMB { get; set; }

        [DataMember]
        public string ALF_CODI { get; set; }

        [DataMember]
        public string ALF_DIRE { get; set; }

        [DataMember]
        public string ALF_CONT { get; set; }

        [DataMember]
        public string ALF_TELE { get; set; }

        [DataMember]
        public int COD_ESTA { get; set; }
    }
}
