using CafeForDevs.Server;
using System.Net;

internal class ServerApplication
{
    private readonly HttpListener _httpListener;
    private readonly Router _router;

    public ServerApplication(HttpListener httpListener, Router router)
    {
        _httpListener = httpListener;
        _router = router;
    }

    internal void Start()
    {
        try
        {
            Console.WriteLine("ServerApplication запущен");
            _httpListener.Start();
            while (true)
            {
                var context = _httpListener.GetContext();
                var path = context.Request.Url.PathAndQuery;
                var handler = _router.Get(path);
                handler.Handle(context);
            }
        }
        catch (Exception ex)
        {
            File.AppendAllText("serverLogs.log", ex.ToString());
            throw;
        }
        finally
        {
            _httpListener.Stop();
        }
    }
}