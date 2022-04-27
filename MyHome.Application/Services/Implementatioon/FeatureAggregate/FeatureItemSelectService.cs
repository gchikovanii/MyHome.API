using Microsoft.EntityFrameworkCore;
using MyHome.Application.Models.Features;
using MyHome.Application.Services.Abstraction.FeatureAggregate;
using MyHome.Domain.Entities.AdvertisementAggregate;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Services.Implementatioon.FeatureAggregate
{
    public class FeatureItemSelectService : IFeatureItemSelectService
    {
        private readonly IFeatureItemSelectRepository _featureItemSelectRepository;
        public FeatureItemSelectService(IFeatureItemSelectRepository featureItemSelectRepository)
        {
            _featureItemSelectRepository = featureItemSelectRepository;
        }

        public async Task<bool> CreateFeatureItemSelect(FeatureItemSelectInputDto input)
        {
            var selectItem = await _featureItemSelectRepository.GetQuery(i => i.Name.Trim().ToLower() == input.Name.Trim().ToLower()).SingleOrDefaultAsync();
            if (selectItem == null)
            {
                await _featureItemSelectRepository.Create(new FeatureItemSelect()
                {
                    Name = input.Name,
                    FeatureItemId = input.FeatureItemId
                });
                return await _featureItemSelectRepository.SaveChangesAsync();
            }
            else
                return false;
            
        }

    }
}
