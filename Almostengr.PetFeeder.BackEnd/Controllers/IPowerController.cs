using Almostengr.PetFeeder.Common.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace Almostengr.PetFeeder.BackEnd.Controllers
{
    public interface IPowerController : IBaseApiController
    {
        ActionResult CreatePower(PowerDto powerDto);
    }
}