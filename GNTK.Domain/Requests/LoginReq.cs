﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GNTK.Domain.Requests
{
    public class LoginReq
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
