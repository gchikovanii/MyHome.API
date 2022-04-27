using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Models.Features
{
    public class FeatureItemsDetailDto
    {
        public int FeatureId { get; set; }
        public string? FeatureItemName { get; set; }
        public string? Content { get; set; }
        public bool? IsCheked { get; set; }
        public string? FeatureItemSelectName { get; set; }
    }
}
