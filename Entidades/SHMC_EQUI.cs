using System;
using System.Runtime.Serialization;

namespace Entidades
{
    [DataContract]
    public class SHMC_EQUI
    {
        [DataMember]
        public int COD_EQUI { get; set; }

        [DataMember]
        public string ALF_SERI { get; set; }

        [DataMember]
        public int COD_ESTA { get; set; }

        [DataMember]
        public int COD_TIPO_UBIC { get; set; }

        [DataMember]
        public int COD_ALMA { get; set; }

        [DataMember]
        public int COD_TECN { get; set; }

        [DataMember]
        public int COD_PUNT_ATEN { get; set; }
    }
}
