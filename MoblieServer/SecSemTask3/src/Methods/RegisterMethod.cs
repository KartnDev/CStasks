using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using SecSemTask3.Models;
using AppContext = SecSemTask3.Database.AppContext;

namespace SecSemTask3.Methods
{
    public class RegisterMethod : IMethod
    {
        private readonly Socket _clientSocket;
        private readonly IDictionary<string, string> _params;

 
        public RegisterMethod(Socket clientSocket, IDictionary<string, string> @params)
        {
            _clientSocket = clientSocket;
            _params = @params;
        }
        
        
        public void WorkSync()
        {
            using AppContext db = new AppContext(); // WTF
            if (!db.Users.Any(user => user.PhoneNum == _params["phone_num"]))
            {
                var user = new UserModel()
                {
                    Name = _params["name"],
                    Surname = _params["surname"],
                    UserToken = Guid.NewGuid(),
                    Password = _params["password"],
                    PhoneNum = _params["phone_num"]
                };
                Console.WriteLine(user);
                
                db.Users.Add(user);
                var result = $"user_token={user.UserToken}&user_id={user.Id}";
                _clientSocket.Send(Encoding.UTF8.GetBytes(result));
            }
            else
            {
                _clientSocket.Send(Encoding.UTF8.GetBytes($"error={100} user exists"));
            }
            
        }

        public void WorkAsync()
        {
            throw new System.NotImplementedException();
        }

        public void InterruptMethod()
        {
            throw new System.NotImplementedException();
        }

        public void AbortMethod()
        {
            throw new System.NotImplementedException();
        }
    }
}