using MyHome.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Domain.Entities.AdvertisementAggregate
{
    public class AdvertisementFeature : Entity
    {
        public int AdvertisementId { get; set; }
        public Advertisement? Advertisement { get; set; }
        public int FeatureItemId { get; set; }
        public FeatureItem? FeatureItem { get; set; }
        public string? Content { get; set; }
        public bool? IsCheked { get; set; }
        public int? FeatureItemSelectId { get; set; }
       

    }
}
