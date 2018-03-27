using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;
using WcfRestJsonResponse.Dtos;

namespace WcfRestJsonResponse
{
    public class Service : IService
    {
        public ResponseDto PostMessage(RequestDto inputMessage)
        {
            //throw new WebFaultException<string>("aaaalllleeeesss mist!!!", HttpStatusCode.InternalServerError);
            return new ResponseDto()
            {
                ResponseMsg = "Calling Post for you " + inputMessage?.RequestMsg,
                Errors = new List<string>(),
                IsFaulty = false,
                ExceptionType = null
            };
        }
    }
}