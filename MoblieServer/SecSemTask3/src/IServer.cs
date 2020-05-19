namespace SecSemTask3
{
    public interface IServer
    {
        bool Serve();
        void Shutdown();
        void Abort();
    }
}