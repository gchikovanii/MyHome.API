using MediatR;
using Microsoft.AspNetCore.Http;
using MyHome.Application.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Commands.Advertisement
{
    public class CreateAdvertisementCommand : IRequest<bool>
    {
        public int AdId { get; set; }
        public decimal Price { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? CadastralCode { get; set; }
        public double Area { get; set; }
        public int UserId { get; set; }
       
    }
}
