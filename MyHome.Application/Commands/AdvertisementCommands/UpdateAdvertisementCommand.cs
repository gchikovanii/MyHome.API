using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Commands.AdvertisementCommands
{
    public class UpdateAdvertisementCommand : IRequest<bool>
    {
        public decimal Price { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? CadastralCode { get; set; }
        public double Area { get; set; }
        public int AdvertisementId { get; set; }
        public string? UserEmail { get; set; }
    }
}
