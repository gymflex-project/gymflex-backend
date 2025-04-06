using GymFlex.Application.UseCases.SpecificRegion.Common;
using GymFlex.Application.UseCases.SpecificRegion.GetSpecificRegion;
using GymFlex.Application.UseCases.SpecificRegion.ListSpecificRegions;
using GymFlex.Domain.SeedWork.SearchableRepository;
using GymFlex.Presentation.ApiModels.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static System.String;

namespace GymFlex.Presentation.Controllers
{
    [ApiController]
    [Route("api/specific-regions")]
    public class SpecificRegionController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        
        [HttpGet]
        [ProducesResponseType(typeof(ListSpecificRegionsOutput), StatusCodes.Status200OK)]
        public async Task<IActionResult> List(
            CancellationToken cancellationToken,        
            [FromQuery] int? page = null,
            [FromQuery(Name = "per_page")] int? perPage = null,
            [FromQuery] string? search = null,
            [FromQuery] string? sort = null,
            [FromQuery] SearchOrder? dir = null
        )
        {
            var input = new ListSpecificRegionsInput();
            if (page is not null) input.Page = page.Value;
            if (perPage is not null) input.PerPage = perPage.Value;
            if (!IsNullOrWhiteSpace(search)) input.Search = search;
            if (!IsNullOrWhiteSpace(sort)) input.Sort = sort;
            if (dir is not null) input.SortDirection = dir.Value;
        
            var output = await _mediator.Send(input, cancellationToken);
            return Ok(
                new ApiResponseList<SpecificRegionModelOutput>(output)
            );
        }
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse<SpecificRegionModelOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var output = await _mediator.Send(new GetSpecificRegionInput(id), cancellationToken);
            return Ok(new ApiResponse<SpecificRegionModelOutput>(output));
        }
    }
}