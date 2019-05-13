using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static TestatNuGet.ViewModel.NavigationViewModel;
using TestatNuGet.ViewModel;

namespace TestatNuGet.ViewModel
{
    public class LogMessageAddViewModel
    {
        private readonly Action<object> navigate;
        public ICommand Navigate { get; set; }
        public ICommand NavigateBack { get; set; }
        public string POD { set; get; }
        public string Location { get; set; }
        public string Hostname { get; set; }
        public int Severity { get; set; }
        public string Message { get; set; }
        public string ConnectionString { get; set; }

        public LogMessageAddViewModel(Action<object> navigate)
        {
            NavigateBack = new BaseCommand(OnNavigateBack);
            Navigate = new BaseCommand(OnNavigate);
            this.navigate = navigate;
       }
        public void AddMessage()
        {
            var connection = new MySqlConnection(ConnectionString);
            try
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "LogMessageAdd";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@i_pod", POD);
                    cmd.Parameters.AddWithValue("@i_location", Location);
                    cmd.Parameters.AddWithValue("@i_hostname", Hostname);
                    cmd.Parameters.AddWithValue("@i_severity", Severity);
                    cmd.Parameters.AddWithValue("@i_message", Message);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Folgender Fehler ist aufgetreten: " + ex.Message);
            }
        }
        private void OnNavigate(object obj)
        {
            AddMessage();
            navigate.Invoke("LogentriesView");
        }
        private void OnNavigateBack(object obj)
        {
            navigate.Invoke("LogentriesView");
        }
    }
}
