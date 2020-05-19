using System.Collections.Generic;
using System.Net.Sockets;

namespace SecSemTask3.Methods
{
    public interface IMethod
    {
        void WorkSync();
        void WorkAsync();
        void InterruptMethod();
        void AbortMethod();
    }
}