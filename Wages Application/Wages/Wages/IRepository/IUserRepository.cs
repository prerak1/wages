﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wages.IRepository
{
    public interface IUserRepository
    {
        /// <summary>
        /// The user logged in.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        int GetUserLoggedin(string email, string password);
    }
}
