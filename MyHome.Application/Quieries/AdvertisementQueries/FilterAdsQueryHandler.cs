using MediatR;
using Microsoft.EntityFrameworkCore;
using MyHome.Application.Models.Advertisements;
using MyHome.Domain.Entities.Constants;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Quieries.AdvertisementQueries
{
    public class FilterAdsQueryHandler : IRequestHandler<FilterAdsQuery, List<GetAdFilteredDto>>
    {
        private readonly IAdvertisementRepository _adRepository;
        public FilterAdsQueryHandler(IAdvertisementRepository adRepository)
        {
            _adRepository = adRepository;
        }
        public async Task<List<GetAdFilteredDto>> Handle(FilterAdsQuery request, CancellationToken cancellationToken)
        {
            var ads = _adRepository.GetQuery()
                    .Include(i => i.AdvertisementFeatures)
                    .ThenInclude(i => i.FeatureItem)
                    .AsQueryable();

            if (request.MinPrice != null && request.MaxPrice == null)
                ads = ads.Where(i => i.Price > request.MinPrice);

            if (request.MinPrice != null && request.MaxPrice != null)
                ads = ads.Where(i => i.Price > request.MinPrice && i.Price < request.MaxPrice);

            if (request.MinPrice == null && request.MaxPrice != null)
                ads = ads.Where(i => i.Price < request.MaxPrice);

            if (request.MinArea != null && request.MaxArea == null)
                ads = ads.Where(i => i.Area > request.MinArea);

            if (request.MinArea != null && request.MaxArea != null)
                ads = ads.Where(i => i.Area > request.MinArea && i.Area < request.MaxArea);

            if (request.MinArea == null && request.MaxArea != null)
                ads = ads.Where(i => i.Area < request.MaxArea);


            if (request.CadastralCode != null)
                ads = ads.Where(i => i.CadastralCode.Contains(request.CadastralCode));

            if (request.Address != null)
                ads = ads.Where(i => i.Address.ToLower().Contains(request.Address.ToLower()));
            #region For Feature Items
            //foreach (var featureItem in request.AdFeatureItems)
            //{
            //    ads.Where(i => i.AdvertisementFeatures
            //            .Any(j => j.FeatureItemId == featureItem.Id
            //            && ((j.FeatureItem.FeatureType == FeatureItemType.Text
            //            && !string.IsNullOrEmpty(j.Content))
            //            || (j.FeatureItem.FeatureType == FeatureItemType.Check
            //            && j.IsCheked == featureItem.IsChecked)
            //            || (j.FeatureItem.FeatureType == FeatureItemType.Select
            //            && j.FeatureItemSelectId == featureItem.FeatureItemSelectId))));
            //}
            #endregion
            return await ads.Select(i => new GetAdFilteredDto()
            {
                Address = i.Address,
                Area = i.Area,
                Price = (int)i.Price,
                CadastralCode = i.CadastralCode,
                CreationTime = i.CreationTime,
                Description = i.Description,
                Title = i.Title,
                AdStatus = i.AdStatus.ToString(),
                UserName = i.AppUser.UserName,
                UserPhone = i.AppUser.PhoneNumber,
                UserEmail = i.AppUser.Email
            }).Skip((request.Page -1) * request.PageSize).Take(request.PageSize).ToListAsync();
        }
    }
}
