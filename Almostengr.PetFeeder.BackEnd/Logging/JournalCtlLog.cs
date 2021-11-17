using System.Diagnostics;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Logging.Interface;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Logging
{
    public class JournalCtlLog : IJournalCtlLog
    {
        public JournalCtlLog(ILogger<JournalCtlLog> logger)
        {
        }

        public async Task<string> RetrieveLogsAsync<Entity>(Entity entity) where Entity : BaseDto
        {
            // journalctl -n 50 -g gnome --no-pager -r

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            
            startInfo.FileName = "/bin/journalctl";
            startInfo.ArgumentList.Add("-n");
            startInfo.ArgumentList.Add("50");
            startInfo.ArgumentList.Add("--no-pager");
            startInfo.ArgumentList.Add("-r");
            startInfo.ArgumentList.Add("-g");
            startInfo.ArgumentList.Add(nameof(Entity));

            startInfo.UseShellExecute = true;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;

            process.StartInfo = startInfo;
            process.Start();

            // Synchronously read the standard output of the spawned process.
            // StreamReader reader = process.StandardOutput;
            // string output = reader.ReadToEnd();
            string output = await process.StandardOutput.ReadToEndAsync();
            string error  = await process.StandardError.ReadToEndAsync();

            process.WaitForExit();

            return output;
        }
    }
}