using System;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Common.Client.Interface
{
    public interface INightLightClient
    {
        Task<Uri> CreateNightLightAsync(NightLightDto nightLight);
    }
}