using MediatR;
using Microsoft.EntityFrameworkCore;
using MyHome.Domain.Entities.AdvertisementAggregate;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Commands.AdvertisementCommands
{
    public class CreateAdFeatureCommandHandler : IRequestHandler<CreateAdFeatureCommand, bool>
    {
        private readonly IAdvertisementRepository _adRepository;
        public CreateAdFeatureCommandHandler(IAdFeatureRepository adFeatureRepository, IAdvertisementRepository adRepository)
        {
            _adRepository = adRepository;
        }
        public async Task<bool> Handle(CreateAdFeatureCommand request, CancellationToken cancellationToken)
        {
            var ad = await _adRepository.GetQuery(i => i.Id == request.AdvertisementId)
                                         .Include(i => i.AdvertisementFeatures)
                                         .SingleOrDefaultAsync();

            if (ad == null)
                return default;

            for (int j = 0; j < request.AdFeatures.Count; j++)
            {
                if (ad.AdvertisementFeatures.Any(i => i.FeatureItemId == request.AdFeatures[j].FeatureItemId))
                {
                    var featureItem = ad.AdvertisementFeatures.Where(i => i.FeatureItemId == request.AdFeatures[j].FeatureItemId).SingleOrDefault();
                    featureItem.Content = request.AdFeatures[j].Content;
                    featureItem.IsCheked = request.AdFeatures[j].IsCheked;
                    featureItem.FeatureItemSelectId = request.AdFeatures[j].FeatireItemSelectId;
                }
                else
                {
                    ad.AdvertisementFeatures.Add(new AdvertisementFeature()
                    {
                        AdvertisementId = request.AdFeatures[j].AdvertisementId,
                        FeatureItemId = request.AdFeatures[j].FeatureItemId,
                        Content = request.AdFeatures[j].Content,
                        FeatureItemSelectId = request.AdFeatures[j].FeatireItemSelectId,
                        IsCheked = request.AdFeatures[j].IsCheked
                    });
                }

            }
            _adRepository.Update(ad);
            return await _adRepository.SaveChangesAsync();

        }
    }
}