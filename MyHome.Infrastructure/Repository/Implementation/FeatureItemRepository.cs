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
    public class FeatureItemRepository : Repository<FeatureItem>, IFeatureItemRepository
    {
        public FeatureItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
