using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.AspNetCore.Mvc;

namespace Almostengr.PetFeeder.BackEnd.Controllers
{
    public interface ISystemSettingController : IBaseApiController
    {
        Task<IActionResult> GetSystemSetting(string settingName);
        Task<IActionResult> GetSystemSettings();
        Task<IActionResult> UpdateSystemSetting(SystemSettingDto systemSetting);
    }
}