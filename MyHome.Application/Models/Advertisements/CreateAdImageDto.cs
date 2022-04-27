using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Models.Advertisements
{
    public class CreateAdImageDto
    {
        public IFormFile? File { get; set; }
        public int AdvertisementId { get; set; }
    }
}
