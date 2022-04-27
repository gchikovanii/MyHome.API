using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHome.API.Constants;
using MyHome.Application.Commands.Advertisement;
using MyHome.Application.Commands.AdvertisementCommands;
using MyHome.Application.Quieries;
using MyHome.Application.Quieries.AdvertisementQueries;

namespace MyHome.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdvertisementController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(nameof(GetAdvertisementByUserId))]
        [Authorize(Roles = UserType.AdminUser)]

        public async Task<IActionResult> GetAdvertisementByUserId([FromQuery] GetAdByUserQeury input)
        {
            var result = await _mediator.Send(input);
            if (result != null)
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpGet(nameof(GetAdvertisementDetails))]
        [Authorize(Roles = UserType.AdminUser)]

        public async Task<IActionResult> GetAdvertisementDetails([FromQuery] GetAdDetailQuery input)
        {
            var result = await _mediator.Send(input);
            if (result != null)
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpGet(nameof(FilterAdvertisements))]
        [Authorize(Roles = UserType.AdminUser)]

        public async Task<IActionResult> FilterAdvertisements([FromQuery] FilterAdsQuery input)
        {
            var result = await _mediator.Send(input);
            if (result != null)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost(nameof(CreateAdvertismenet))]
        [Authorize(Roles = UserType.AdminSuperVisor)]

        public async Task<IActionResult> CreateAdvertismenet(CreateAdvertisementCommand input)
        {
            var result = await _mediator.Send(input);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost(nameof(SaveAdvertisementFeatures))]
        [Authorize(Roles = UserType.AdminSuperVisor)]

        public async Task<IActionResult> SaveAdvertisementFeatures(CreateAdFeatureCommand input)
        {
            var result = await _mediator.Send(input);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpPut(nameof(UpdateAdvertisement))]
        [Authorize(Roles = UserType.AdminSuperVisor)]

        public async Task<IActionResult> UpdateAdvertisement(UpdateAdvertisementCommand input)
        {
            var result = await _mediator.Send(input);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete(nameof(DeleteAdvertisement))]
        [Authorize(Roles = UserType.AdminSuperVisor)]

        public async Task<IActionResult> DeleteAdvertisement([FromQuery]DeleteAdvertismenetCommand input)
        {
            var result = await _mediator.Send(input);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }

    }
}
