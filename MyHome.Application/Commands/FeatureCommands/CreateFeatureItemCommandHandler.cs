using MediatR;
using MyHome.Domain.Entities.AdvertisementAggregate;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Commands.Features
{
    public class CreateFeatureItemCommandHandler : IRequestHandler<CreateFeatureItemCommand, bool>
    {
        private readonly IFeatureItemRepository _featureItemRepository;
        public CreateFeatureItemCommandHandler(IFeatureItemRepository featureItemRepository)
        {
            _featureItemRepository = featureItemRepository;
        }
        public async Task<bool> Handle(CreateFeatureItemCommand request, CancellationToken cancellationToken)
        {
            await _featureItemRepository.Create(new FeatureItem()
            {
                Name = request.Name,
                IsActives = request.IsActives,
                FeatureType = request.FeatureType,
                FeatureId = request.FeatureId
            });
            return await _featureItemRepository.SaveChangesAsync();
        }
    }
}
