using System;
using System.Runtime.Serialization;

namespace WcfServices.Errores
{
    [DataContract]
    public class GeneralException
    {
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }
}