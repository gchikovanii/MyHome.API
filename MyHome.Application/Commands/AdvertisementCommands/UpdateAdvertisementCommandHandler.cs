using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyHome.Application.Models.Advertisements;
using MyHome.Domain.Entities.UserAggregate;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Commands.AdvertisementCommands
{
    public class UpdateAdvertisementCommandHandler : IRequestHandler<UpdateAdvertisementCommand, bool>
    {
        private readonly IAdvertisementRepository _adRepository;
        private readonly UserManager<AppUser> _userManager;
        public UpdateAdvertisementCommandHandler(IAdvertisementRepository adRepository, UserManager<AppUser> userManager)
        {
            _adRepository = adRepository;
            _userManager = userManager;
        }
        public async Task<bool> Handle(UpdateAdvertisementCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userManager.FindByEmailAsync(request.UserEmail);
            var advertisement = await _adRepository.GetQuery(i => i.Id == request.AdvertisementId).SingleOrDefaultAsync();

            if(userExist != null && advertisement != null)
            {
                advertisement.Title = request.Title;
                advertisement.Price = request.Price;
                advertisement.Description = request.Description;
                advertisement.Address = request.Address;
                advertisement.Area = request.Area;
                advertisement.CadastralCode = request.CadastralCode;
                _adRepository.Update(advertisement);
                return await _adRepository.SaveChangesAsync();
            }
            else
                return false;
           
        
        }
    }
}
