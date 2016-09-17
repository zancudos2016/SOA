using System;
using System.Runtime.Serialization;

namespace Entidades
{
    [DataContract]
    public class SHMD_ATEN_REPO
    {
        [DataMember]
        public int COD_ATEN_REPO { get; set; }

        [DataMember]
        public int COD_ATEN { get; set; }

        [DataMember]
        public string ALF_COME { get; set; }

        [DataMember]
        public int COD_EQUI_LLEG { get; set; }

        [DataMember]
        public int COD_EQUI_SALE { get; set; }

        [DataMember]
        public int COD_ESTA_EQUI_SALE { get; set; }

        [DataMember]
        public int COD_ESTA_ATEN { get; set; }

        [DataMember]
        public int COD_SEST { get; set; }

        [DataMember]
        public DateTime FEC_PART { get; set; }

        [DataMember]
        public string ALF_LATI_PART { get; set; }

        [DataMember]
        public string ALF_LONG_PART { get; set; }

        [DataMember]
        public DateTime FEC_LLEG { get; set; }

        [DataMember]
        public string ALF_LATI_LLEG { get; set; }

        [DataMember]
        public string ALF_LONG_LLEG { get; set; }

        [DataMember]
        public string IMG_FOTO_LLEG { get; set; }

        [DataMember]
        public DateTime FEC_REPO { get; set; }

        [DataMember]
        public string ALF_LATI_REPO { get; set; }

        [DataMember]
        public string ALF_LONG_REPO { get; set; }

        [DataMember]
        public string IMG_FOTO_REPO { get; set; }
    }
}
