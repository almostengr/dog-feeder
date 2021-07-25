using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Common.Client.Interface
{
    public interface IWateringClient
    {
        Task<IList<Watering>> GetAllWateringsAsync();
        Task<IList<Watering>> GetRecentWateringsAsync();
        Task<Watering> GetWateringAsync(int id);
        Task<Uri> CreateWateringAsync(Watering watering);
        Task<bool?> GetWaterBowlStatus();
    }
    
}