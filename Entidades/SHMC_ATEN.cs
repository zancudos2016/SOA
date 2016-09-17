using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades
{
    [DataContract]
    public class SHMC_ATEN
    {
        public SHMC_ATEN()
        {
            LST_ATEN = new List<SHMC_ATEN>();
        }
        [DataMember]
        public int COD_ATEN { get; set; }

        [DataMember]
        public int COD_PUNT_ATEN { get; set; }

        [DataMember]
        public int COD_TIPO { get; set; }

        [DataMember]
        public string FEC_ATEN { get; set; }

        [DataMember]
        public string ALF_COME { get; set; }

        [DataMember]
        public string FEC_PROG { get; set; }

        [DataMember]
        public int COD_TECN { get; set; }

        [DataMember]
        public int COD_ESTA { get; set; }
        [DataMember]
        public string ALF_PTOA { get; set; }
        [DataMember]
        public List<SHMC_ATEN> LST_ATEN { get; set; }
        public bool IND_ERRO { get; set; }
        [DataMember]
        public string ALF_ERRO { get; set; }
    }
}
