using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wages.IRepository;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace Wages.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        private static string VerifyUser = "ValidateLoginUser";

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public int GetUserLoggedin(string email, string password)
        {
            int returnVal = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(VerifyUser, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmailAddress", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.Add("@UserId", SqlDbType.Int);
                cmd.Parameters["@UserId"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                returnVal = Convert.ToInt32(cmd.Parameters["@UserId"].Value);
                connection.Close();
            }
            return returnVal;
        }
    }
}
