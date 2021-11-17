using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Logging.Interface
{
    public interface IJournalCtlLog
    {
        Task<string> RetrieveLogsAsync<Entity>(Entity entity) where Entity : BaseDto;
    }
}