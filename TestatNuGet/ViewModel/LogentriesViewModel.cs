using System.Collections.ObjectModel;
using TestatNuGet.Model;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Input;
using System;
using System.Windows;
using static TestatNuGet.ViewModel.NavigationViewModel;
using DuplicateCheckerLib;

namespace TestatNuGet.ViewModel
{

    public class LogentriesViewModel
    {
        private readonly Action<object> navigate;
        private LoadButtonCommand _loadButtonCommand;
        private ConfirmButtonCommand _confirmButtonCommand;
        private FindDuplicatesButtonCommand _findDuplicatesButtonCommand;
        private DuplicateChecker _duplicateChecker;

        public ICommand Navigate { get; set; }
        public ObservableCollection<LogentriesModel> Logentries { get; set; }
        public ObservableCollection<LogentriesModel> DuplicateLogentries { get; set; }
        public string ConnectionString { get; set; } // Server = localhost; Database = inventarisierungsloesung; Uid = root; Pwd = password;
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
        public FindDuplicatesButtonCommand FindDuplicatesButtonCommand
        {
            get { return this._findDuplicatesButtonCommand; }
            set { this._findDuplicatesButtonCommand = value; }
        }

        public LogentriesViewModel(Action<object> navigate)
        {
            Navigate = new BaseCommand(OnNavigate);
            this.navigate = navigate;

            ConnectionString = "Server = localhost; Database = ; Uid = root; Pwd = ;";

            _loadButtonCommand = new LoadButtonCommand(this);
            _confirmButtonCommand = new ConfirmButtonCommand(this);
            Logentries = new ObservableCollection<LogentriesModel>();
            DuplicateLogentries = new ObservableCollection<LogentriesModel>();
            _duplicateChecker = new DuplicateChecker();
            _findDuplicatesButtonCommand = new FindDuplicatesButtonCommand(this);
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
                                reader.GetValue(reader.GetOrdinal("Location")) as string,
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
        public void CheckForDuplicates()
        {
            var dc = _duplicateChecker.FindDuplicates(Logentries);
        }
        private void OnNavigate(object obj)
        {
            navigate.Invoke("LogMessageAddView");
        }
    }
}

