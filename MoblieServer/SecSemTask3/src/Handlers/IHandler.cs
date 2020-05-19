using System.Net.Sockets;

namespace SecSemTask3.Handlers
{
    public interface IHandler
    {
        void Handle(Socket clientSocket);

        void Interrupt();
        void Abort();
    }
}