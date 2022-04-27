using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHome.API.Constants;
using MyHome.Application.Commands;
using MyHome.Application.Commands.Features;
using MyHome.Application.Models.Features;
using MyHome.Application.Services.Abstraction.AdvertismentAggregate;
using MyHome.Application.Services.Abstraction.FeatureAggregate;

namespace MyHome.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IFeatureItemSelectService _featureItemSelect;
        private readonly IAdFeaturetService _getDraftService;
        public FeatureController(IMediator mediator, IFeatureItemSelectService featureItemSelect, IAdFeaturetService getDraftService)
        {
            _mediator = mediator;
            _featureItemSelect = featureItemSelect; 
            _getDraftService = getDraftService;
        }

        [HttpGet(nameof(GetDraft))]
        [Authorize(Roles = UserType.AdminSuperVisor)]

        public async Task<IActionResult> GetDraft()
        {
            var result = await _getDraftService.GetFeatureDraft();
            if (result != null)
                return Ok(result);
            else
                return BadRequest(result);
            
        }

        [HttpPost(nameof(CreateFeature))]
        [Authorize(Roles = UserType.AdminSuperVisor)]

        public async Task<IActionResult> CreateFeature(CreateFeatureCommand input)
        {
            var result = await _mediator.Send(input);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost(nameof(CreateFeatureItem))]
        [Authorize(Roles = UserType.AdminSuperVisor)]

        public async Task<IActionResult> CreateFeatureItem([FromForm]CreateFeatureItemCommand input)
        {
            var result = await _mediator.Send(input);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpPost(nameof(CreateFeatureItemSelect))]
        [Authorize(Roles = UserType.AdminSuperVisor)]

        public async Task<IActionResult> CreateFeatureItemSelect(FeatureItemSelectInputDto input)
        {
            var result = await _featureItemSelect.CreateFeatureItemSelect(input);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }



    }
}
