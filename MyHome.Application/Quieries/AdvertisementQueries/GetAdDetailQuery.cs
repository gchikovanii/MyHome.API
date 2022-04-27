using MediatR;
using MyHome.Application.Models.Advertisements;
using MyHome.Domain.Entities.AdvertisementAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Quieries.AdvertisementQueries
{
    public class GetAdDetailQuery : IRequest<List<GetAdDetailsDto>>
    {
        public int AdvertismenetId { get; set; }
    }
}
