using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Models;
using Almostengr.PetFeeder.BackEnd.Repository.Interfaces;
using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Services
{
    public class FeedingService : IFeedingService
    {
        private readonly IFeedingRepository _repository;
        private readonly ILogger<FeedingService> _logger;

        public FeedingService(IFeedingRepository repository, ILogger<FeedingService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<FeedingDto> CreateFeedingAsync(FeedingDto feedingDto)
        {
            Feeding feeding = new Feeding(feedingDto);
            feeding.Created = DateTime.Now;

            return await _repository.CreateFeedingAsync(feeding);
        }

        public async Task<FeedingDto> GetFeedingAsync(int id)
        {
            return await _repository.GetFeedingAsync(id);
        }

        public async Task<List<FeedingDto>> GetFeedingsAsync()
        {
            return await _repository.GetFeedingsAsync();
        }
    }
}