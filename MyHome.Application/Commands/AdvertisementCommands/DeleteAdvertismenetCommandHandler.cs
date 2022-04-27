using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyHome.Domain.Entities.UserAggregate;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Commands.AdvertisementCommands
{
    public class DeleteAdvertismenetCommandHandler : IRequestHandler<DeleteAdvertismenetCommand, bool>
    {
        private readonly IAdvertisementRepository _adRepository;
        private readonly UserManager<AppUser> _userManager;
        public DeleteAdvertismenetCommandHandler(IAdvertisementRepository adRepository, UserManager<AppUser> userManager)
        {
            _adRepository = adRepository;
            _userManager = userManager;
        }
        public async Task<bool> Handle(DeleteAdvertismenetCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userManager.FindByEmailAsync(request.UserEmail);
            var advertisement = await _adRepository.GetQuery(i => i.Id == request.AdvertisementId).SingleOrDefaultAsync();
            if (userExist != null && advertisement != null)
                _adRepository.Delete(advertisement);
                return await _adRepository.SaveChangesAsync();
           
        }
    }
}
