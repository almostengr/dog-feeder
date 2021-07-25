using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.Client.Interface;

namespace Almostengr.PetFeeder.Common.Client
{
    public class PowerClient : BaseClient, IPowerClient
    {
        public async Task ShutDown()
        {
            throw new System.NotImplementedException();
        }

        public async Task Restart()
        {
            throw new System.NotImplementedException();
        }
    }
}