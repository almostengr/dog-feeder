using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Almostengr.DogFeeder.Api.Controllers
{
    public interface IControllerBase
    {
        [HttpGet]
        Task<ActionResult<T>> GetAsync<T>();

        [HttpGet]
        Task<ActionResult<T>> GetAsync<T>(int id);

        [HttpPost]
        Task<ActionResult<T>> PostAsync<T>(T t);
    }
}