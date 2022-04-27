using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Commands
{
    public class CreateFeatureCommand : IRequest<bool>
    {
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
