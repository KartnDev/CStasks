using System;
using System.Diagnostics.CodeAnalysis;

namespace SecSemTask3.Models
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class UserModel
    {
        public int Id { get; set; }
        public Guid UserToken { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNum { get; set; }
        public string Password { get; set; }
    }
}