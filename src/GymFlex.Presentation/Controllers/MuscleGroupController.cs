using GymFlex.Application.UseCases.MuscleGroup.Common;
using GymFlex.Application.UseCases.MuscleGroup.CreateMuscleGroup;
using GymFlex.Application.UseCases.MuscleGroup.DeleteMuscleGroup;
using GymFlex.Application.UseCases.MuscleGroup.GetMuscleGroup;
using GymFlex.Application.UseCases.MuscleGroup.ListMuscleGroups;
using GymFlex.Application.UseCases.MuscleGroup.UpdateMuscleGroup;
using GymFlex.Domain.SeedWork.SearchableRepository;
using GymFlex.Presentation.ApiModels.Response;
using GymFlex.Presentation.ApiModels.UpdateApiInput;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymFlex.Presentation.Controllers
{
    [ApiController]
    [Route("api/muscle-groups")]
    public class MuscleGroupController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        
        [HttpGet]
        [ProducesResponseType(typeof(ListMuscleGroupsOutput), StatusCodes.Status200OK)]
        public async Task<IActionResult> List(
            CancellationToken cancellationToken,        
            [FromQuery] int? page = null,
            [FromQuery(Name = "per_page")] int? perPage = null,
            [FromQuery] string? search = null,
            [FromQuery] string? sort = null,
            [FromQuery] SearchOrder? dir = null
        )
        {
            var input = new ListMuscleGroupsInput();
            if (page is not null) input.Page = page.Value;
            if (perPage is not null) input.PerPage = perPage.Value;
            if (!String.IsNullOrWhiteSpace(search)) input.Search = search;
            if (!String.IsNullOrWhiteSpace(sort)) input.Sort = sort;
            if (dir is not null) input.SortDirection = dir.Value;
        
            var output = await _mediator.Send(input, cancellationToken);
            return Ok(
                new ApiResponseList<MuscleGroupModelOutput>(output)
            );
        }
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse<MuscleGroupModelOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var output = await _mediator.Send(new GetMuscleGroupInput(id), cancellationToken);
            return Ok(new ApiResponse<MuscleGroupModelOutput>(output));
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<MuscleGroupModelOutput>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Create(
            [FromBody] CreateMuscleGroupInput input, 
            CancellationToken cancellationToken
        )
        {
            var output = await _mediator.Send(input, cancellationToken);
            return CreatedAtAction(
                nameof(GetById), 
                new { Id = output.Id },
                new ApiResponse<MuscleGroupModelOutput>(output)
            );
        }
        
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse<MuscleGroupModelOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id, 
            [FromBody] UpdateMuscleGroupApiInput apiInput,
            CancellationToken cancellationToken
        )
        {
            var output = await _mediator.Send(
                new UpdateMuscleGroupInput(
                    id,
                    apiInput.Name), 
                cancellationToken
            );
            return Ok(new ApiResponse<MuscleGroupModelOutput>(output));
        }
        
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteMuscleGroupInput(id), cancellationToken);
            return NoContent();
        }
    }
}