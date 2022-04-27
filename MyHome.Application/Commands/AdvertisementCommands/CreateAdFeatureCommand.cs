using MediatR;
using MyHome.Application.Models.Advertisements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Commands.AdvertisementCommands
{
    public class CreateAdFeatureCommand : IRequest<bool>
    {
        public int AdvertisementId { get; set; }
        public List<CreateAdFeatureDto>? AdFeatures { get; set; }
    }
}
