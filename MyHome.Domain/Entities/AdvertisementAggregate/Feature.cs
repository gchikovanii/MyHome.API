using MyHome.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Domain.Entities.AdvertisementAggregate
{
    public class Feature : Entity
    {
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<FeatureItem>? FeatureItems { get; set; }
    }
}
