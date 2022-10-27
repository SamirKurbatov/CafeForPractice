using CafeForDevs.Server;
using CafeForDevs.Server.Handlers;
using System.Net;
using System.Net.Http.Headers;

var baseUrl = new Uri("http://localhost:37820/");

var httpListener = new HttpListener();
httpListener.Prefixes.Add(baseUrl.ToString());

var handlers = new List<IHandler>();
handlers.Add(new MenuHandler());
handlers.Add(new OrderHandler());

foreach (var handler in handlers)
{
    var handlerUrl = new Uri(baseUrl, handler.Path + "/ ");
    httpListener.Prefixes.Add(handlerUrl.ToString());
}

var router = new Router(handlers);

var application = new ServerApplication(httpListener, router);
application.Start();