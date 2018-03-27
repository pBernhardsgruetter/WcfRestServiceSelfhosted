using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WcfRestJsonResponse.Dtos
{
    [DataContract]
    public class ResponseDto
    {
        [DataMember(Order = 2)]
        public string ResponseMsg { get; set; }

        [DataMember(Order = 1)]
        public bool IsFaulty { get; set; }

        [DataMember(Order = 3)]
        public IEnumerable<string> Errors { get; set; }

        [DataMember(Order = 4)]
        public string ExceptionType { get; set; }
    }
}