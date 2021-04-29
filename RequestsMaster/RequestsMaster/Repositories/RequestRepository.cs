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
    public class RequestRepository
    {
        public List<Request> getAllRequestsBy(int user_id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.ConnectionValue("RequestMaster")))
            {
                return connection.Query<Request>($"SELECT * FROM t_requests WHERE user_id = '{user_id}'").ToList();
            }
        }

        public List<Request> getAllRequests()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.ConnectionValue("RequestMaster")))
            {
                return connection.Query<Request>($"SELECT * FROM t_requests").ToList();
            }
        }

        public List<Request> getPendingRequests()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.ConnectionValue("RequestMaster")))
            {
                return connection.Query<Request>($"SELECT * FROM t_requests WHERE req_status = 'Pending'").ToList();
            }
        }

        public void newRequest(Request request)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.ConnectionValue("RequestMaster")))
            {
                connection.Query<Request>($"INSERT INTO t_requests (created, req_type, userid, req_status) VALUES ('2021-04-29T08:21:53.13', 'create user',1,'Pending')").ToList();
            }
        }
    }
}