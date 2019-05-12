using System.Collections.ObjectModel;
using System.ComponentModel;
using TestatNuGet.Model;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Input;
using TestatNuGet.View;
using System.Runtime.CompilerServices;
using System;
using System.Windows;
using static TestatNuGet.ViewModel.NavigationViewModel;

namespace TestatNuGet.ViewModel
{

    public class LogentriesViewModel
    {
        private readonly Action<object> navigate;
        private LoadButtonCommand _loadButtonCommand;
        private ConfirmButtonCommand _confirmButtonCommand;

        public ICommand Navigate { get; set; }
        public ObservableCollection<LogentriesModel> Logentries { get; set; }
        public string ConnectionString { get; set; }
        public LoadButtonCommand LoadButtonCommand
        {
            get{ return this._loadButtonCommand;}
            set{this._loadButtonCommand = value;}
        }
        public ConfirmButtonCommand ConfirmButtonCommand
        {
            get{return this._confirmButtonCommand;}
            set{this._confirmButtonCommand = value;}
        }
        public LogentriesViewModel(Action<object> navigate)
        {
            Navigate = new BaseCommand(OnNavigate);
            this.navigate = navigate;
            _loadButtonCommand = new LoadButtonCommand(this);
            _confirmButtonCommand = new ConfirmButtonCommand(this);
            Logentries = new ObservableCollection<LogentriesModel>();
            ConnectionString = "Server = localhost; Database = ; Uid = root; Pwd = ;";
        }
        public void LoadLogentries()
        {
            this.Logentries.Clear();
            var connection = new MySqlConnection(ConnectionString);
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show("Folgender Fehler ist aufgetreten: " + ex.Message);
            }
        }
        public void ConfirmLogentries(int id)
        {
            var connection = new MySqlConnection(ConnectionString);
            try
            { 
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "LogClear";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_logentries_id", id);
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
            navigate.Invoke("LogMessageAddView");
        }

    }
}

