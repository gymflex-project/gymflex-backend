using GymFlex.Application.UseCases.Exercise.Common;
using GymFlex.Application.UseCases.Exercise.GetExercise;
using GymFlex.Application.UseCases.Exercise.ListExercises;
using GymFlex.Domain.SeedWork.SearchableRepository;
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
    }
}