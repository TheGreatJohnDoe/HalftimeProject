using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using RequestsMaster.Models;
using RequestsMaster.Utility;

namespace RequestsMaster.Repositories
{
    public class UserRepository
    {
        public List<User> getUserById(int userid)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.ConnectionValue("RequestMaster")))
            {
                return connection.Query<User>($"SELECT * FROM t_users WHERE id = '{userid}'").ToList();
            }
        }
    }
}