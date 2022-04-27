using MediatR;
using MyHome.Application.Models.Advertisements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Quieries.AdvertisementQueries
{
    public class FilterAdsQuery : IRequest<List<GetAdFilteredDto>>
    {
        public string? CadastralCode { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string? Address { get; set; }
        public double? MinArea { get; set; }
        public double? MaxArea { get; set; }
        public List<FilterAdFeatureItems>? AdFeatureItems { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
    }
}
