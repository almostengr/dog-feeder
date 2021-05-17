using Microsoft.AspNetCore.Mvc;

namespace Almostengr.DogFeeder.Api.Controllers
{
    public interface IControllerBase
    {
        [HttpGet]
        ActionResult<T> GetAll<T>();

        [HttpGet]
        ActionResult<T> Get<T>(int id);

        [HttpPost]
        ActionResult<T> Post<T>(T t);
    }
}