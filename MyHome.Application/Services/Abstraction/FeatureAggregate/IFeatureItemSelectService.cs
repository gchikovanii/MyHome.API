using MyHome.Application.Models.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Services.Abstraction.FeatureAggregate
{
    public interface IFeatureItemSelectService
    {
        Task<bool> CreateFeatureItemSelect(FeatureItemSelectInputDto input);
    }
}
