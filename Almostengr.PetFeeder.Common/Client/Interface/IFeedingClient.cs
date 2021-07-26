using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Common.Client.Interface
{
    public interface IFeedingClient
    {
        Task<IList<FeedingDto>> GetAllFeedingsAsync();
        Task<FeedingDto> GetFeedingAsync(int id);
        Task<Uri> CreateFeedingAsync(FeedingDto feeding);
    }
}