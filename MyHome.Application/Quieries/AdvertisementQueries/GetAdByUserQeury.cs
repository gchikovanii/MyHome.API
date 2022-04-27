using MediatR;
using MyHome.Application.Models.Advertisements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Quieries
{
    public class GetAdByUserQeury : IRequest<List<GetAdvertisementsByUserNameDto>>
    {
        public int Id { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        
    }
}
