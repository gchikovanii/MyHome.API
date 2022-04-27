using MyHome.Domain.Entities.AdvertisementAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Models.Features
{
    public class FeatureDraftDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public List<FeatureItemDto> FeatureItems { get; set; }
        public FeatureDraftDto()
        {

        }
        public FeatureDraftDto(Feature feature)
        {
            Id = feature.Id;
            Name = feature.Name;
            IsActive = feature.IsActive;
            FeatureItems = feature.FeatureItems?.Select(i => new FeatureItemDto(i))?.ToList();
        }
    }
}
