using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHome.API.Constants;
using MyHome.Application.Models.Advertisements;
using MyHome.Application.Services.Abstraction.CloudinaryAggregate;

namespace MyHome.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ICloudinaryService _cloudinaryService;
        public ImageController(ICloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
        }
        [HttpPost(nameof(UploadImageOnCloudinary))]
        [Authorize(Roles = UserType.AdminSuperVisor)]

        public async Task<IActionResult> UploadImageOnCloudinary(IFormFile input)
        {
            return Ok(await _cloudinaryService.UploadImage(input));
        }

    }
}
