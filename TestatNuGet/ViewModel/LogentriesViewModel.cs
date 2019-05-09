using System.Collections.ObjectModel;
using System.ComponentModel;
using TestatNuGet.Model;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Input;

namespace TestatNuGet.ViewModel
{
    public class LogentriesViewModel
    {
        private LoadButtonCommand _loadButtonCommand;
        public string ConnectionString { get; set; } // Server=localhost;Database=semesterarbeit;Uid=root;Pwd=password;
        public ObservableCollection<LogentriesModel> Logentries { get; set; }
        public LoadButtonCommand LoadButtonCommand
        {
            get
            {
                return this._loadButtonCommand;
            }
            set
            {
                this._loadButtonCommand = value;
            }
        }

        public LogentriesViewModel()
        {
            _loadButtonCommand = new LoadButtonCommand(this);
            ConnectionString = "Server = localhost; Database = ; Uid = root; Pwd = ;";
            Logentries = new ObservableCollection<LogentriesModel>();

        }

        public void LoadLogentries()
        {
            this.Logentries.Clear();
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            using (var cmd = connection.CreateCommand())
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
            connection.Close();
        }

        public void ConfirmLogentries(int id)
        {
            var connection = new MySqlConnection(ConnectionString);
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = "LogClear";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void AddMessage(string pod, string hostname, string level, string message)
        {
            var connection = new MySqlConnection(ConnectionString);
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

