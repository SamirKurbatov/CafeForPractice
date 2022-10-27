using CafeForDevs.Server.Handlers;

namespace CafeForDevs.Server
{
    internal class Router
    {
        private readonly List<IHandler> _handlers;

        public Router(List<IHandler> handlers)
        {
            _handlers = handlers;
        }

        public IHandler Get(string path)
        {
            var handler = _handlers.SingleOrDefault(x => x.Path == path);
            return handler;
        }
    }
}
