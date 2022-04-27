using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyHome.Domain.Constants;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Jobs
{
    public class AdExpireDateJob : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public AdExpireDateJob(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await ExcecuteJob(stoppingToken);
        }
        public async Task ExcecuteJob(CancellationToken token)
        {

            using(var scope = _scopeFactory.CreateScope())
            {
                var _adRepository = scope.ServiceProvider.GetRequiredService<IAdvertisementRepository>();
                var ads = _adRepository.GetQuery(i => i.CreationTime.AddDays(30) <= DateTime.Now);
                var totalCount = await ads.CountAsync();
                var data = await ads.ToListAsync();

                var numberOfChunks = Math.Ceiling(Convert.ToDecimal(totalCount) / 50);
                for (int i = 0; i < numberOfChunks; i++)
                {
                    foreach (var ad in data.Skip((i - 1) * 50).Take(50))
                    {
                        ad.Title = "Canceled!";
                        ad.AdStatus = AdStatus.Inactive; 
                    }
                    await _adRepository.SaveChangesAsync();
                }
            }

        }

    }
}
