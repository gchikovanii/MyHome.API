using MediatR;
using MyHome.Domain.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Commands.Features
{
    public class CreateFeatureItemCommand : IRequest<bool>
    {
        public string? Name { get; set; }
        public bool IsActives { get; set; }
        public FeatureItemType FeatureType { get; set; }
        public int FeatureId { get; set; }
    }
}
