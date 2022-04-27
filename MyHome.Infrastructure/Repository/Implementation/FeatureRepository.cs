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
    public class FeatureRepository : Repository<Feature>, IFeatureRepository
    {
        public FeatureRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
