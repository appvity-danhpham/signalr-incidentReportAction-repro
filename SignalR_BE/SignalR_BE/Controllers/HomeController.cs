using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using SignalR_BE.Models;
using System.Diagnostics;

namespace SignalR_BE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private LogLevel LogLevel { get; }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7128/incidentHub")
                .ConfigureLogging(logging =>
                {
                    // Add our existing logger as a logger provider
                    logging.AddProvider(_logger.AsLoggerProvider());
                    logging.AddFilter("Microsoft.AspNetCore.SignalR", LogLevel);
                })
                .Build();

            try
            {
                await connection.StartAsync();
                object incidentReport = new IncidentReport
                {
                    id = "12345",
                    identifier = "IR-001",
                    sender = "System",
                    sent = DateTime.UtcNow.ToString("o"),
                    created = DateTime.UtcNow.ToString("o"),
                    statusEntityTypeId = "active",
                    status = "Active",
                    msgTypeEntityTypeId = "alert",
                    msgType = "Alert",
                    source = "System",
                    scopeEntityTypeId = "public",
                    scope = "Public",
                    restriction = "None",
                    addresses = "All",
                    code = "Code123",
                    note = "This is a test incident report.",
                    references = "Ref123",
                    incidents = "Incident1, Incident2",
                    categoryEntityTypeId = "safety",
                    category = "Safety",
                    urgencyEntityTypeId = "high",
                    urgency = "High",
                    severityEntityTypeId = "moderate",
                    severity = "Moderate",
                    certaintyEntityTypeId = "likely",
                    certainty = "Likely",
                    responseTypeEntityTypeId = "monitoring",
                    responseType = "Monitoring",
                    _event = "Test Event",
                    headline = "Test Headline",
                    description = "This is a test description.",
                    categoryCode = "Cat123",
                    severityCode = "Sev123",
                    effective = DateTime.UtcNow.ToString("o"),
                    expires = DateTime.UtcNow.AddHours(1).ToString("o"),
                    type = "Test Type",
                    isExpired = false.ToString(),
                    parentIRAlertIds = ""
                };
                await connection.InvokeAsync("UpdateIncidentReport", incidentReport);
                await connection.StopAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public static class LoggerExtensions
    {
        // Extension method to create an ILoggerProvider from an existing ILogger
        public static ILoggerProvider AsLoggerProvider(this ILogger logger)
        {
            return new ExistingLoggerProvider(logger);
        }

        private class ExistingLoggerProvider : ILoggerProvider
        {
            public ExistingLoggerProvider(ILogger logger)
            {
                _logger = logger;
            }

            public ILogger CreateLogger(string categoryName)
            {
                return _logger;
            }

            public void Dispose()
            {
                return;
            }

            private readonly ILogger _logger;
        }
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
