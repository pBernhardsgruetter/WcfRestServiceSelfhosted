using System;
using System.Runtime.Serialization;

namespace WcfRestJsonResponse.Dtos
{
    [DataContract]
    class JsonErrorDetails
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string DetailMessage { get; set; }

        [DataMember]
        public string ExceptionType { get; set; }
    }
}
