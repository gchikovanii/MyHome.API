using MyHome.Domain.Entities.AdvertisementAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Models.Features
{
    public class FeatureItemSelectDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int FeatureItemId { get; set; }
        public FeatureItemSelectDto()
        {

        }
        public FeatureItemSelectDto(FeatureItemSelect featureItemSelect)
        {
            Id = featureItemSelect.Id;
            Name = featureItemSelect.Name;
            FeatureItemId = featureItemSelect.FeatureItemId;
        }
    }
}
