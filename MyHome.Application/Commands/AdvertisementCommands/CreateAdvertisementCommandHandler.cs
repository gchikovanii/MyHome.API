using MediatR;
using MyHome.Application.Commands.Advertisement;
using MyHome.Application.Filters;
using MyHome.Application.Models.Advertisements;
using MyHome.Application.Services.Abstraction.AdvertismentAggregate;
using MyHome.Domain.Constants;
using MyHome.Domain.Entities.AdvertisementAggregate;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Commands.AdvertisementCommands
{
    public class CreateAdvertisementCommandHandler : IRequestHandler<CreateAdvertisementCommand, bool>
    {
        private readonly IAdvertisementRepository _advertisement;

        public CreateAdvertisementCommandHandler(IAdvertisementRepository advertisement)
        {
            _advertisement = advertisement;
        }
        public async Task<bool> Handle(CreateAdvertisementCommand request, CancellationToken cancellationToken)
        {
            await _advertisement.Create(new Domain.Entities.AdvertisementAggregate.Advertisement()
            {
                Price = request.Price,
                Address = request.Address,
                Area = request.Area,
                CadastralCode = request.CadastralCode,
                Description = request.Description,
                Title = request.Title,
                UserId = request.UserId,
                AdStatus = AdStatus.Active
            });
            return await _advertisement.SaveChangesAsync();


        }
    }
}
