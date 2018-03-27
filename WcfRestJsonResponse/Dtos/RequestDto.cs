using System.Runtime.Serialization;

namespace WcfRestJsonResponse.Dtos
{
    [DataContract]
    public class RequestDto
    {
        [DataMember(IsRequired = true)]
        public string RequestMsg { get; set; }
    }
}