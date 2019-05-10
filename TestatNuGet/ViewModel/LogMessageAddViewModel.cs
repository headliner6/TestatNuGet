using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestatNuGet.ViewModel
{
    public class LogMessageAddViewModel
    {
        public LogMessageAddViewModel() { }
        public void AddMessage(string pod, string hostname, string level, string message)
        {
            var connection = new MySqlConnection("");
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = "LogMessageAdd";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Pod", pod);
                cmd.Parameters.AddWithValue("@Hostname", hostname);
                cmd.Parameters.AddWithValue("@Level", level);
                cmd.Parameters.AddWithValue("@Logmessage", message);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}
