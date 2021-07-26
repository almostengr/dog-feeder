using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Common.Client.Interface
{
    public interface IWateringClient
    {
        Task<IList<WateringDto>> GetAllWateringsAsync();
        Task<IList<WateringDto>> GetRecentWateringsAsync();
        Task<WateringDto> GetWateringAsync(int id);
        Task<Uri> CreateWateringAsync(WateringDto watering);
        Task<bool?> GetWaterBowlStatus();
    }
    
}