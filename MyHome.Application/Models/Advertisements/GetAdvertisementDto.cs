using MyHome.Domain.Entities.AdvertisementAggregate;
using MyHome.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Models.Advertisements
{
    public class GetAdvertisementDto
    {
        public decimal Price { get; set; }
        public DateTimeOffset CreationTime { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? CadastralCode { get; set; }
        public double Area { get; set; }
        public int UserId { get; set; }
        public AppUser? AppUser { get; set; }
        public ICollection<AdvertisementFeature>? AdvertisementFeatures { get; set; }
    }
}
