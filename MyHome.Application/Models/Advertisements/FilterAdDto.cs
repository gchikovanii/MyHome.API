using MyHome.Domain.Entities.AdvertisementAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Models.Advertisements
{
    public class FilterAdDto
    {
        public string? CadastralCode { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public DateTimeOffset CreationTime { get; set; }
        public int Price { get; set; }
        public string? Address { get; set; }
        public double Area { get; set; }
        public int UserId { get; set; }
        public List<AdvertisementFeature>? AdvertisementFeatures { get; set; }
    }
}
