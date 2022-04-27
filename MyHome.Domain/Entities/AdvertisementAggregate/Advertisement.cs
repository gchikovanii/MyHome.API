using MyHome.Domain.Constants;
using MyHome.Domain.Entities.Base;
using MyHome.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Domain.Entities.AdvertisementAggregate
{
    public class Advertisement : Entity
    {
        public decimal Price { get; set; }
        public DateTimeOffset CreationTime { get; protected set; } = DateTimeOffset.Now;
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? CadastralCode { get; set; }
        public double Area { get; set; }
        public int UserId { get; set; }
        public AdStatus AdStatus { get; set; }
        public AppUser? AppUser { get; set; }
        public ICollection<AdvertisementFeature>? AdvertisementFeatures { get; set; }


    }
}
