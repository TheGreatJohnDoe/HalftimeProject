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
        public List<Request> getRequestById(int requestid)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.ConnectionValue("RequestMasterDB")))
            {
                return connection.Query<Request>($"SELECT * FROM t_requests WHERE id = '{requestid}'").ToList();
            }
        }
        public List<Request> getAllRequestsByUser(string userid)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.ConnectionValue("RequestsMasterDB")))
            {
                return connection.Query<Request>($"SELECT * FROM t_requests WHERE userid = '{userid}'").ToList();
            }
        }

        public List<Request> getAllRequests()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.ConnectionValue("RequestMasterDB")))
            {
                return connection.Query<Request>($"SELECT * FROM t_requests").ToList();
            }
        }

        public List<Request> getPendingRequests()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.ConnectionValue("RequestMasterDB")))
            {
                return connection.Query<Request>($"SELECT * FROM t_requests WHERE req_status = 'Pending'").ToList();
            }
        }

        public void newRequest(Request request)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBHelper.ConnectionValue("RequestMasterDB")))
            {
                connection.Query<Request>($"INSERT INTO t_requests (created, req_type, userid, req_status, req_details) VALUES ('{request.created.ToString("O")}', '{request.req_type}',{request.userid},'{request.req_status}', {request.req_details})").ToList();
            }
        }

        //public string omerHatzair(String Pazam)
        //{
        //    if (User.toString()== "Omer") {
        //        return "Paur";
        //    } 
        //    else if (User.toString()=="Nir" || User.toString() == "Tali")
        //    {
        //        return "Pazam olam";
        //    }
        //    else
        //    {
        //        return "You Must change your password :)";
        //        // we did git commit
        //    }
        //}
    }
}