﻿using backend.Models;
using System.Data.SqlClient;

namespace backend.Helper
{
    public static class Connection
    {
        private static readonly string connectionString = ConnectionStrings.ticketDB;

        public static List<T> QueryObjectList<T>(this string sql) where T : class, new()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        List<T> list = new List<T>();
                        while (dr.Read())
                        {
                            list.Add(Util.ConvertToObject<T>(dr));
                        }
                        return list;
                    }
                }
            }
        }

        public static int ExecuteSQLCommand(string sql, List<SqlParameter> parameters)
        {
            using (SqlConnection openCon = new SqlConnection(connectionString))
            {
                using (SqlCommand querySaveStaff = new SqlCommand(sql))
                {
                    querySaveStaff.Connection = openCon;
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            querySaveStaff.Parameters.Add(parameter);
                        }
                    }
                    openCon.Open();

                    return querySaveStaff.ExecuteNonQuery();
                }
            }
        }
    }
}
