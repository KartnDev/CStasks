﻿using System;

namespace SecSemTask3
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Serve();
        }
    }
}