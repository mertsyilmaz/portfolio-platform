using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Contracts.Auth
{
    public class LoginResponse
    {
        public string AccessToken { get; set; } = null!;
    }
}
