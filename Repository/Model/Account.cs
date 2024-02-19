using System;
using System.Collections.Generic;

namespace Repository.Model
{
    public partial class Account
    {
        public Account()
        {
        }
        public int AccountId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? Type { get; set; }
    }
}
