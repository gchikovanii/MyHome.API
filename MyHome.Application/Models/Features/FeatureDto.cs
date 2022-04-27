using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Models.Features
{
    public class FeatureDto
    {
        public int Id { get; set; }
        public string FeatureName { get; set; }
        public List<FeatureItemsDetailDto> FeatureItems { get; set; }
    }
}
