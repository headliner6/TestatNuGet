using System.Collections.ObjectModel;
using System.ComponentModel;
using TestatNuGet.Model;
using MySql.Data.MySqlClient;

namespace TestatNuGet.ViewModel
{
    public class LogentriesViewModel
    {
        public string ConnectionString { get; set; } // Server=localhost;Database=semesterarbeit;Uid=root;Pwd=password;
        public ObservableCollection<LogentriesModel> Logentries { get; set; }

        public LogentriesViewModel()
        {
            Logentries = new ObservableCollection<LogentriesModel>();
        }

        public void LoadLogentries()
        {
            var con = new MySqlConnection(ConnectionString);
            con.Open();
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT id, pod, location, hostname, severity, timestamp, message FROM v_logentries";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Logentries.Add(new LogentriesModel(
                            reader.GetInt32("Id"),
                            reader.GetString("Pod"),
                            reader.GetString("Location"),
                            reader.GetString("Hostname"),
                            reader.GetInt32("Severity"),
                            reader.GetString("Timestamp"),
                            reader.GetString("Message")
                            ));
                    }
                }
            }
        }
    }
}

