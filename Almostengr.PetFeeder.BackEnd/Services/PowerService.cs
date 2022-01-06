using System.Diagnostics;
using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Services
{
    public class PowerService : IPowerService
    {
        private readonly ILogger<PowerService> _logger;
        private Process _process;
        private ProcessStartInfo _startInfo;

        public PowerService(ILogger<PowerService> logger)
        {
            _logger = logger;
            _process = new Process();
            _startInfo = new ProcessStartInfo();
        }

        public void Reboot()
        {
            _logger.LogInformation("System restart requested");

            _startInfo.FileName = "reboot";
            ExecuteProcess();
        }

        public void Shutdown()
        {
            _logger.LogInformation("System shutdown requested");

            _startInfo.FileName = "shutdown";
            _startInfo.ArgumentList.Add("-h");
            _startInfo.ArgumentList.Add("now");
            ExecuteProcess();
        }

        private void ExecuteProcess()
        {
            _startInfo.UseShellExecute = true;
            _startInfo.CreateNoWindow = true;
            _process.StartInfo = _startInfo;
            _process.Start();
        }

    }
}