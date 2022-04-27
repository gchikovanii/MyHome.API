using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Models.Advertisements
{
    public class FilterAdFeatureItems
    {
        public int Id { get; set; }
        public int FeatureId { get; set; }
        public string? FeatureItemName { get; set; }
        public string? Content { get; set; }
        public bool? IsChecked { get; set; }
        public int FeatureItemSelectId { get; set; }
    }
}
