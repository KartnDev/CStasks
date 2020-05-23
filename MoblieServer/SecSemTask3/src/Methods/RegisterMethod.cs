using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using NLog;
using SecSemTask3.Models;
using AppContext = SecSemTask3.Database.AppContext;

namespace SecSemTask3.Methods
{
    public class RegisterMethod : IMethod
    {
        private readonly Socket _clientSocket;
        private readonly string _sqlServerName;
        private readonly IDictionary<string, string> _params;
        private readonly Logger _logger;


        public RegisterMethod(Socket clientSocket,string sqlServerName,  IDictionary<string, string> @params, Logger logger)
        {
            _clientSocket = clientSocket;
            _sqlServerName = sqlServerName;
            _params = @params;
            _logger = logger;
        }
        
        
        public void WorkSync()
        {
            using(AppContext db = new AppContext(_sqlServerName))
            {
                // WTF
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

                    db.Users.Add(user);
                    db.SaveChanges();
                    var result = $"user_token={user.UserToken.ToString()}&user_id={user.Id.ToString()}";
                    _clientSocket.Send(Encoding.UTF8.GetBytes(result));
                    
                    _logger.Info($"User {user.Id.ToString()} with Name:{user.Name} " +
                                 $"and Surname {user.Surname} " +
                                 $"and PhoneNumber: {user.PhoneNum} successfully registered");
                }
                else
                {
                    _clientSocket.Send(Encoding.UTF8.GetBytes($"error={100.ToString()} user exists"));
                    _logger.Info("Error register - user exists!");
                }
            }
        }

        public void WorkAsync()
        {
            throw new System.NotImplementedException();
        }

        public void InterruptMethod()
        {
            if (_clientSocket != null)
            {
                _clientSocket.Disconnect(false);
                _clientSocket.Close();
                _clientSocket.Dispose();
            }
        }

        public void AbortMethod()
        {
            _clientSocket.Dispose();
        }
    }
}