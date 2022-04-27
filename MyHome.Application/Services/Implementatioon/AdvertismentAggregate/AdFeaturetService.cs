using Microsoft.EntityFrameworkCore;
using MyHome.Application.Models.Features;
using MyHome.Application.Services.Abstraction.AdvertismentAggregate;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Services.Implementatioon.AdvertismentAggregate
{
    public class AdFeaturetService : IAdFeaturetService
    {
        private readonly IFeatureRepository _featureRepository;

        public AdFeaturetService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<IEnumerable<FeatureDraftDto>> GetFeatureDraft()
        {
            var features = await _featureRepository.GetQuery(i => i.IsActive)
                .Include(i => i.FeatureItems)
                .ThenInclude(i => i.FeatureItemSelects).ToListAsync();
            return features?.Select(i => new FeatureDraftDto(i));

        }


    }
}
