using GymFlex.Application.UseCases.SpecificRegion.Common;
using GymFlex.Application.UseCases.SpecificRegion.CreateSpecificRegion;
using GymFlex.Application.UseCases.SpecificRegion.DeleteSpecificRegion;
using GymFlex.Application.UseCases.SpecificRegion.GetSpecificRegion;
using GymFlex.Application.UseCases.SpecificRegion.ListSpecificRegions;
using GymFlex.Application.UseCases.SpecificRegion.UpdateSpecificRegion;
using GymFlex.Domain.SeedWork.SearchableRepository;
using GymFlex.Presentation.ApiModels.Response;
using GymFlex.Presentation.ApiModels.UpdateApiInput;
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
        
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<SpecificRegionModelOutput>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Create(
            [FromBody] CreateSpecificRegionInput input, 
            CancellationToken cancellationToken
        )
        {
            var output = await _mediator.Send(input, cancellationToken);
            return CreatedAtAction(
                nameof(GetById), 
                new { Id = output.Id },
                new ApiResponse<SpecificRegionModelOutput>(output)
            );
        }
        
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse<SpecificRegionModelOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id, 
            [FromBody] UpdateSpecificRegionApiInput apiInput,
            CancellationToken cancellationToken
        )
        {
            var output = await _mediator.Send(
                new UpdateSpecificRegionInput(
                    id,
                    apiInput.Name,
                    apiInput.MuscleGroupId
                ), 
                cancellationToken
            );
            return Ok(new ApiResponse<SpecificRegionModelOutput>(output));
        }
        
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteSpecificRegionInput(id), cancellationToken);
            return NoContent();
        }
    }
}