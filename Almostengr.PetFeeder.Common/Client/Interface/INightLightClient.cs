using System;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Common.Client.Interface
{
    public interface INightLightClient
    {
        Task<Uri> CreateNightLightAsync(NightLight nightLight);
    }
}