using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace WcfRestJsonResponse
{
    /// <summary>
    ///     This class is a custom implementation of the WebHttpBehavior.
    ///     The main of this class is to handle exception and to serialize those as requests that will be understood by the web
    ///     application.
    /// </summary>
    public class ExtendedWebHttpBehavior : WebHttpBehavior
    {
        protected override void AddServerErrorHandlers(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            // clear default erro handlers.
            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Clear();

            // add our own error handler.
            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Add(new JsonErrorHandler());
            //BehaviorExtensionElement
        }
    }
}