using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.AspNetCore.Mvc;

namespace Almostengr.PetFeeder.BackEnd.Controllers
{
    public interface IFeedingController : IBaseApiController
    {
        Task<IActionResult> CreateFeeding(FeedingDto feedingDto);
        Task<IActionResult> GetFeeding(int id);
        Task<IActionResult> GetFeedings();
    }
}