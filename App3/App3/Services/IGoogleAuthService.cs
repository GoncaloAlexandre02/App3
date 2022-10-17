using System;
using System.Collections.Generic;
using System.Text;
using App3.Models;

namespace App3.Services
{
    public interface IGoogleAuthService
    {
        void Login(Action<GoogleUser, string> OnLoginComplete);

        void Logout();
    }
}
