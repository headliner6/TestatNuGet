using System.Collections.ObjectModel;
using System.ComponentModel;
using TestatNuGet.Model;
using MySql.Data.MySqlClient;

namespace TestatNuGet.ViewModel
{
    public class LogentriesViewModel : INotifyPropertyChanged
    {
        public string ConnectionString { get; set; }
        public ObservableCollection<LogentriesModel> Logentries { get; set; }

        public LogentriesViewModel()
        {
            LoadLogentries();
        }

        public void LoadLogentries()
        {
            var con = new MySqlConnection("Server=localhost;Database=semesterarbeit;Uid=root;Pwd=password;");
            var Logentries = new ObservableCollection<LogentriesModel>();
            con.Open();
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT id, pod, location, hostname, severity, timestamp, message FROM v_logentries";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Logentries.Add(new LogentriesModel(
                            1, "", "", "", 1, "", ""

                            ));
                    }
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

