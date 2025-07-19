using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class IncidentHub : Hub
{
    public async Task UpdateIncidentReport(IncidentReport incidentReport)
    {
        await Clients.All.SendAsync("incidentReportAction", incidentReport);
    }
    public class IncidentReport
    {
        public virtual string id { get; set; }

        public virtual string identifier { get; set; }

        public virtual string sender { get; set; }

        public virtual string sent { get; set; }

        public virtual string created { get; set; }

        public virtual string statusEntityTypeId { get; set; }

        public virtual string status { get; set; }

        public virtual string msgTypeEntityTypeId { get; set; }

        public virtual string msgType { get; set; }

        public virtual string source { get; set; }

        public virtual string scopeEntityTypeId { get; set; }

        public virtual string scope { get; set; }

        public virtual string restriction { get; set; }

        public virtual string addresses { get; set; }

        public virtual string code { get; set; }

        public virtual string note { get; set; }

        public virtual string references { get; set; }

        public virtual string incidents { get; set; }

        public virtual string categoryEntityTypeId { get; set; }

        public virtual string category { get; set; }

        public virtual string urgencyEntityTypeId { get; set; }

        public virtual string urgency { get; set; }

        public virtual string severityEntityTypeId { get; set; }

        public virtual string severity { get; set; }

        public virtual string certaintyEntityTypeId { get; set; }

        public virtual string certainty { get; set; }

        public virtual string responseTypeEntityTypeId { get; set; }

        public virtual string responseType { get; set; }
        public virtual string _event { get; set; }
        public virtual string headline { get; set; }
        public virtual string description { get; set; }
        public virtual string categoryCode { get; set; }
        public virtual string severityCode { get; set; }
        public virtual string effective { get; set; }
        public virtual string expires { get; set; }
        public virtual string type { get; set; }
        public virtual string isExpired { get; set; }
        public virtual string parentIRAlertIds { get; set; }
    }
}