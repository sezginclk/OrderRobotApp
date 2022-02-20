using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRobot.Service.Abstract
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
