using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Models.Advertisements
{
    public class CreateAdFeatureDto
    {
        public int AdvertisementId { get; set; }
        public int FeatureItemId { get; set; }
        public string Content { get; set; }
        public bool? IsCheked { get; set; }
        public int? FeatireItemSelectId { get; set; }
    }
}
