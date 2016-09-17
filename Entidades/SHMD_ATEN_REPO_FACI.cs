using System;
using System.Runtime.Serialization;

namespace Entidades
{
    [DataContract]
    public class SHMD_ATEN_REPO_FACI
    {
        [DataMember]
        public int COD_ATEN { get; set; }

        [DataMember]
        public int COD_FACI { get; set; }

        [DataMember]
        public bool IND_MARC { get; set; }
    }
}
