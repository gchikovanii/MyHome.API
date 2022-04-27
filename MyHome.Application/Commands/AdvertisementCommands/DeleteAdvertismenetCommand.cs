using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Commands.AdvertisementCommands
{
    public class DeleteAdvertismenetCommand : IRequest<bool>
    {
        public int AdvertisementId { get; set; }
        public string? UserEmail { get; set; }
    }
}
