using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wages.IRepository;
using Wages.IServices;

namespace Wages.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userrepository;

        public AccountService(IUserRepository userrepository)
        {
            _userrepository = userrepository;
        }

        public int GetUserLoggedin(string email, string password)
        {
            return _userrepository.GetUserLoggedin(email,password);
        }
    }
}
