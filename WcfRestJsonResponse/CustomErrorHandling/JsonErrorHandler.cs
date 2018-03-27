using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text.RegularExpressions;
using WcfRestJsonResponse.Dtos;

namespace WcfRestJsonResponse.CustomErrorHandling
{
    public class JsonErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            // Yes, we handled this exception...
            return true;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            var errorCodeMsg = Regex.Replace(error.Message, @"\s+", "");
            var httpStatusCodeParsed = Enum.TryParse(errorCodeMsg, out HttpStatusCode httpErrorCode);
            var exceptionDetailMessage = error.GetType().GetProperty("Detail")?.GetValue(error) as string;

            // Create message
            var jsonError = new ResponseDto
            {
                ResponseMsg = error.Message,
                ExceptionType = error.GetType().Name,
                IsFaulty = true,
                Errors = !string.IsNullOrEmpty(exceptionDetailMessage) ? new List<string> {exceptionDetailMessage} : new List<string>()
            };
            fault = Message.CreateMessage(version, "", jsonError,
                new DataContractJsonSerializer(typeof(ResponseDto)));

            // Tell WCF to use JSON encoding rather than default XML
            var wbf = new WebBodyFormatMessageProperty(WebContentFormat.Json);
            fault.Properties.Add(WebBodyFormatMessageProperty.Name, wbf);


            var alternativeHttpCode = error.Source.Contains("System.Runtime.Serialization")
                ? HttpStatusCode.BadRequest
                : HttpStatusCode.InternalServerError;
            // Modify response
            var rmp = new HttpResponseMessageProperty
            {
                StatusCode = httpStatusCodeParsed ? httpErrorCode : alternativeHttpCode,
                StatusDescription = exceptionDetailMessage ?? string.Empty
            };
            rmp.Headers[HttpResponseHeader.ContentType] = "application/json";
            fault.Properties.Add(HttpResponseMessageProperty.Name, rmp);
        }
    }
}