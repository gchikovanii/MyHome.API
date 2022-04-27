using MyHome.Domain.Entities.Base;
using MyHome.Domain.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Domain.Entities.AdvertisementAggregate
{
    public class FeatureItem : Entity
    {
        public  string? Name { get; set; }
        public bool IsActives { get; set; }
        public FeatureItemType FeatureType { get; set; }
        public int FeatureId { get; set; }
        public Feature? Feature { get; set; }
        public ICollection<AdvertisementFeature>? AdvertisementFeatures { get; set; }
        public ICollection<FeatureItemSelect>? FeatureItemSelects { get; set; }
    }
}
