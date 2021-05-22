using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Almostengr.PetFeeder.Api.Worker
{
    public interface IWaterBowlWorker
    {
        void CloseWaterValve();
        Task DoOpenWaterValve();
        bool IsWaterBowlFull();
    }
}