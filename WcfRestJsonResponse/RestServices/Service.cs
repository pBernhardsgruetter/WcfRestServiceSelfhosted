using System.Collections.Generic;
using WcfRestJsonResponse.Dtos;

namespace WcfRestJsonResponse.RestServices
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