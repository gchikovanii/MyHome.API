using MyHome.Domain.Entities.AdvertisementAggregate;
using MyHome.Domain.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Models.Features
{
    public class FeatureItemDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsActives { get; set; }
        public FeatureItemType FeatureType { get; set; }
        public int FeatureId { get; set; }
        public List<FeatureItemSelectDto>? FeatureItemSelects { get; set; }
        public FeatureItemDto()
        {

        }
        public FeatureItemDto(FeatureItem featureItem)
        {
            Id = featureItem.Id;
            Name = featureItem.Name;
            FeatureType = featureItem.FeatureType;
            IsActives = featureItem.IsActives;
            FeatureId = featureItem.FeatureId;
            FeatureItemSelects = featureItem.FeatureItemSelects?.Select(i => new FeatureItemSelectDto(i))?.ToList();
        }
    }
}
