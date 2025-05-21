using GymFlex.Application.UseCases.ExerciseSubstitution.Common;
using GymFlex.Application.UseCases.ExerciseSubstitution.CreateExerciseSubstitution;
using GymFlex.Application.UseCases.ExerciseSubstitution.DeleteExerciseSubstitution;
using GymFlex.Application.UseCases.ExerciseSubstitution.GetExerciseSubstitution;
using GymFlex.Application.UseCases.ExerciseSubstitution.ListExerciseSubstitutions;
using GymFlex.Application.UseCases.ExerciseSubstitution.UpdateExerciseSubstitution;
using GymFlex.Domain.SeedWork.SearchableRepository;
using GymFlex.Presentation.ApiModels.Response;
using GymFlex.Presentation.ApiModels.UpdateApiInput;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymFlex.Presentation.Controllers
{
    [ApiController]
    [Route("api/exercise-substitutions")]
    public class ExerciseSubstitutionController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        
        [HttpGet]
        [ProducesResponseType(typeof(ListExerciseSubstitutionsOutput), StatusCodes.Status200OK)]
        public async Task<IActionResult> List(
            CancellationToken cancellationToken,        
            [FromQuery] int? page = null,
            [FromQuery(Name = "per_page")] int? perPage = null,
            [FromQuery] string? search = null,
            [FromQuery] string? sort = null,
            [FromQuery] SearchOrder? dir = null
        )
        {
            var input = new ListExerciseSubstitutionsInput();
            if (page is not null) input.Page = page.Value;
            if (perPage is not null) input.PerPage = perPage.Value;
            if (!String.IsNullOrWhiteSpace(search)) input.Search = search;
            if (!String.IsNullOrWhiteSpace(sort)) input.Sort = sort;
            if (dir is not null) input.SortDirection = dir.Value;
        
            var output = await _mediator.Send(input, cancellationToken);
            return Ok(
                new ApiResponseList<ExerciseSubstitutionModelOutput>(output)
            );
        }
        
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse<ExerciseSubstitutionModelOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            var output = await _mediator.Send(new GetExerciseSubstitutionInput(id), cancellationToken);
            return Ok(new ApiResponse<ExerciseSubstitutionModelOutput>(output));
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<ExerciseSubstitutionModelOutput>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Create(
            [FromBody] CreateExerciseSubstitutionInput input, 
            CancellationToken cancellationToken
        )
        {
            var output = await _mediator.Send(input, cancellationToken);
            return CreatedAtAction(
                nameof(GetById), 
                new { Id = output.Id },
                new ApiResponse<ExerciseSubstitutionModelOutput>(output)
            );
        }
        
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse<ExerciseSubstitutionModelOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id, 
            [FromBody] UpdateExerciseSubstitutionApiInput apiInput,
            CancellationToken cancellationToken
        )
        {
            var output = await _mediator.Send(
                new UpdateExerciseSubstitutionInput(
                    id,
                    apiInput.EquivalenceLevel,
                    apiInput.Notes,
                    apiInput.ExerciseId,
                    apiInput.SubstituteExerciseId), 
                cancellationToken
            );
            return Ok(new ApiResponse<ExerciseSubstitutionModelOutput>(output));
        }
        
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteExerciseSubstitutionInput(id), cancellationToken);
            return NoContent();
        }
    }
}