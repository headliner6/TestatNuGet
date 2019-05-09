using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestatNuGet.Model
{
    public class LogentriesModel
    {
        public int Id { get; set; }
        public string Pod { get; set; }
        public string Location { get; set; }
        public string Hostname { get; set; }
        public int Severity { get; set; }
        public string Timestamp { get; set; }
        public string Message { get; set; }
        private bool Confirmed { get; set; }

        public LogentriesModel(int id, string pod, string location, string hostname, int severity, string timestamp, string message, bool confirmed)
        {
            this.Id = id;
            this.Pod = pod;
            this.Location = location;
            this.Hostname = hostname;
            this.Severity = severity;
            this.Timestamp = timestamp;
            this.Message = message;
            this.Confirmed = confirmed;
        }
    }
}
