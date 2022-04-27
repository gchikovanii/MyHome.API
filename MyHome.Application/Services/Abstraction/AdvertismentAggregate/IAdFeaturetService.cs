using MyHome.Application.Models.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Services.Abstraction.AdvertismentAggregate
{
    public interface IAdFeaturetService
    {
        Task<IEnumerable<FeatureDraftDto>> GetFeatureDraft();
    }
}
