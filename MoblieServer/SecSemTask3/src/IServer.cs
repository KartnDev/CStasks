namespace SecSemTask3
{
    public interface IServer
    {
        void Serve();
        void Shutdown();
        void Abort();
    }
}