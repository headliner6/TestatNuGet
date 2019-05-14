using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using static TestatNuGet.ViewModel.NavigationViewModel;

namespace TestatNuGet.ViewModel
{
    public class LogMessageAddViewModel
    {
        private readonly Action<object> navigate;
        private bool _validationOk;
        public ICommand Navigate { get; set; }
        public ICommand NavigateBack { get; set; }
        public string POD { set; get; }
        public string Hostname { get; set; }
        public string Severity { get; set; }
        public string Message { get; set; }
        public string ConnectionString { get; set; }

        public LogMessageAddViewModel(Action<object> navigate)
        {
            NavigateBack = new BaseCommand(OnNavigateBack);
            Navigate = new BaseCommand(OnNavigate);
            this.navigate = navigate;
       }
        public void AddMessageAndValidation()
        {
            if (string.IsNullOrEmpty(POD))
            {
                MessageBox.Show("POD darf nicht leer sein!");
            }
            else if (string.IsNullOrEmpty(Hostname))
            {
                MessageBox.Show("Hostname darf nicht leer sein!");
            }
            else if (string.IsNullOrEmpty(Severity))
            {
                MessageBox.Show("Severity darf nicht leer sein!");
            }
            else if (Regex.IsMatch(Severity, "[^0-9]"))
            {
                MessageBox.Show("Severity darf nur Zahlen enthalten!");
                Severity = Severity.Remove(Severity.Length - 1);
            }
            else if (string.IsNullOrEmpty(Message))
            {
                MessageBox.Show("Message darf nicht leer sein!");
            }
            else
            {
                _validationOk = true;
                var connection = new MySqlConnection(ConnectionString);
                try
                {
                    connection.Open();
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "LogMessageAdd";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@i_pod", POD);
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
        }
        private void OnNavigate(object obj)
        {
            AddMessageAndValidation();
            if (_validationOk == true)
            {
                navigate.Invoke("LogentriesView");
            }
        }
        private void OnNavigateBack(object obj)
        {
            navigate.Invoke("LogentriesView");
        }
    }
}
