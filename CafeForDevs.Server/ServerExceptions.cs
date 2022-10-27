namespace CafeForDevs.Server
{
    internal class ServerExceptions : Exception
    {
        public ServerExceptions() { }
        public ServerExceptions(string message) : base(message) { }
        public ServerExceptions(string message, Exception inner) : base(message, inner) { }
    }
}
