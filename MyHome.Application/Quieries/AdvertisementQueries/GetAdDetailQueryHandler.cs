using MediatR;
using Microsoft.EntityFrameworkCore;
using MyHome.Application.Models.Advertisements;
using MyHome.Application.Models.Features;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Quieries.AdvertisementQueries
{
    public class GetAdDetailQueryHandler : IRequestHandler<GetAdDetailQuery, List<GetAdDetailsDto>>
    {
        private readonly IAdvertisementRepository _adRepository;
        private readonly IFeatureRepository _featureRepository;
        public GetAdDetailQueryHandler(IAdvertisementRepository adRepository, IFeatureRepository featureRepository)
        {
            _adRepository = adRepository;
            _featureRepository = featureRepository;
        }
        public async Task<List<GetAdDetailsDto>> Handle(GetAdDetailQuery request, CancellationToken cancellationToken)
        {
            var adDetails = await _adRepository.GetQuery(i => i.Id == request.AdvertismenetId)
                .Include(i => i.AppUser)
                .Include(i => i.AdvertisementFeatures)
                .ThenInclude(i => i.FeatureItem)
                .ThenInclude(i => i.Feature)
                .Include(i => i.AdvertisementFeatures)
                .ThenInclude(i => i.FeatureItem)
                .ThenInclude(i => i.FeatureItemSelects)
                .ToListAsync();

            var adList = new List<GetAdDetailsDto>();
            var features = await _featureRepository.GetCollectionsAsync(i => i.IsActive);

            foreach (var detail in adDetails)
            {
                adList.Add(new GetAdDetailsDto()
                {
                    Address = detail.Address,
                    Area = detail.Area,
                    CadastralCode = detail.CadastralCode,
                    CreationTime = detail.CreationTime,
                    Description = detail.Description,
                    Title = detail.Title,
                    Price = (int)detail.Price,
                    UserId = detail.UserId,
                    UserName = detail.AppUser.UserName,
                    UserEmail = detail.AppUser.Email,
                    UserPhone = detail.AppUser.PhoneNumber,
                    Features = features.Select(f => new FeatureDto()
                    {

                        Id = f.Id,
                        FeatureName = f.Name,
                        FeatureItems = detail.AdvertisementFeatures.GroupBy(g => g.FeatureItem.FeatureId)
                        .SingleOrDefault(j => j.Key == f.Id)
                        .Select(i => new FeatureItemsDetailDto()
                        {
                            FeatureId = f.Id,
                            Content = i.Content,
                            FeatureItemName = i.FeatureItem.Name,
                            FeatureItemSelectName = i.FeatureItem.FeatureItemSelects.Select(i => i.Name)
                                                                                    .FirstOrDefault(),
                            IsCheked = i.IsCheked
                        }).ToList()
                    }).ToList()
                });
            }
            return adList;


        }
    }
}
