using System.ServiceModel;
using System.ServiceModel.Web;
using WcfRestJsonResponse.Dtos;

namespace WcfRestJsonResponse.RestServices
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json)]
        ResponseDto PostMessage(RequestDto inputMessage);
    }
}