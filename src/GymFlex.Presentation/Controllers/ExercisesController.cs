using GymFlex.Application.UseCases.Exercise.Common;
using GymFlex.Application.UseCases.Exercise.CreateExercise;
using GymFlex.Application.UseCases.Exercise.DeleteExercise;
using GymFlex.Application.UseCases.Exercise.GetExercise;
using GymFlex.Application.UseCases.Exercise.ListExercises;
using GymFlex.Application.UseCases.Exercise.UpdateExercise;
using GymFlex.Domain.SeedWork.SearchableRepository;
using GymFlex.Presentation.ApiModels.UpdateApiInput;
using GymFlex.Presentation.ApiModels.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymFlex.Presentation.Controllers
{
    [ApiController]
    [Route("api/exercises")]
    public class ExercisesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        
        [HttpGet]
        [ProducesResponseType(typeof(ListExercisesOutput), StatusCodes.Status200OK)]
        public async Task<IActionResult> List(
            CancellationToken cancellationToken,        
            [FromQuery] int? page = null,
            [FromQuery(Name = "per_page")] int? perPage = null,
            [FromQuery] string? search = null,
            [FromQuery] string? sort = null,
            [FromQuery] SearchOrder? dir = null
        )
        {
            var input = new ListExercisesInput();
            if (page is not null) input.Page = page.Value;
            if (perPage is not null) input.PerPage = perPage.Value;
            if (!String.IsNullOrWhiteSpace(search)) input.Search = search;
            if (!String.IsNullOrWhiteSpace(sort)) input.Sort = sort;
            if (dir is not null) input.SortDirection = dir.Value;
        
            var output = await _mediator.Send(input, cancellationToken);
            return Ok(
                new ApiResponseList<ExerciseDetailedModelOutput>(output)
            );
        }
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse<ExerciseModelOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var output = await _mediator.Send(new GetExerciseInput(id), cancellationToken);
            return Ok(new ApiResponse<ExerciseModelOutput>(output));
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<ExerciseModelOutput>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Create(
            [FromBody] CreateExerciseInput input, 
            CancellationToken cancellationToken
        )
        {
            var output = await _mediator.Send(input, cancellationToken);
            return CreatedAtAction(
                nameof(GetById), 
                new { Id = output.Id },
                new ApiResponse<ExerciseModelOutput>(output)
            );
        }
        
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse<ExerciseModelOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id, 
            [FromBody] UpdateExerciseApiInput apiInput,
            CancellationToken cancellationToken
        )
        {
            var output = await _mediator.Send(
                new UpdateExerciseInput(
                    id,
                    apiInput.Name, 
                    apiInput.MuscleGroupId, 
                    apiInput.SpecificRegionId, 
                    apiInput.DifficultyLevel,
                    apiInput.Description, 
                    apiInput.ExerciseCategory,
                    apiInput.EquipmentType), 
                cancellationToken
            );
            return Ok(new ApiResponse<ExerciseModelOutput>(output));
        }
        
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteExerciseInput(id), cancellationToken);
            return NoContent();
        }
    }
}