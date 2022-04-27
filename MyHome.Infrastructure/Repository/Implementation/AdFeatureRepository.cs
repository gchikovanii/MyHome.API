using MyHome.Domain.Entities.AdvertisementAggregate;
using MyHome.Infrastructure.DataContext;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Infrastructure.Repository.Implementation
{
    public class AdFeatureRepository : Repository<AdvertisementFeature>, IAdFeatureRepository
    {
        public AdFeatureRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
