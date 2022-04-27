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
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand, bool>
    {
        private readonly IFeatureRepository _featureRepository;
        public CreateFeatureCommandHandler(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }
        public async Task<bool> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            await _featureRepository.Create(new Feature()
            {
                Name = request.Name,
                IsActive = request.IsActive
            });
            return await _featureRepository.SaveChangesAsync();
        }
    }
}
