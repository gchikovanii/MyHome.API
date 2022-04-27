using MediatR;
using Microsoft.EntityFrameworkCore;
using MyHome.Application.Models.Advertisements;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Quieries
{
    public class GetAdByUserQeuryHandler : IRequestHandler<GetAdByUserQeury,List<GetAdvertisementsByUserNameDto>>
    {
        private readonly IAdvertisementRepository _advertisement;
        public GetAdByUserQeuryHandler(IAdvertisementRepository advertisement)
        {
            _advertisement = advertisement;
        }

        public async Task<List<GetAdvertisementsByUserNameDto>> Handle(GetAdByUserQeury request, CancellationToken cancellationToken)
        {
            var advetisments = _advertisement.GetQuery(i => i.UserId == request.Id)
                .Skip((request.Page - 1) * request.PageSize).Take(request.PageSize);
            return await advetisments.Select(i => new GetAdvertisementsByUserNameDto()
            {
                UserId = i.UserId,
                Address = i.Address,
                Area = i.Area,
                CadastralCode = i.CadastralCode,
                Title = i.Title,
                Price = (int)i.Price,
                CreationTime = i.CreationTime,
                Description = i.Description,
                Status = i.AdStatus.ToString(),
                UserName = i.AppUser.UserName,
                UserEmail = i.AppUser.Email,
                UserPhoneNumber = i.AppUser.PhoneNumber
            }).ToListAsync();
        }
    }
}
