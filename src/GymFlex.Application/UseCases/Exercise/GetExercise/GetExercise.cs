﻿using GymFlex.Application.UseCases.Exercise.Common;
using GymFlex.Domain.Repositories;

namespace GymFlex.Application.UseCases.Exercise.GetExercise
{
    public class GetExercise : IGetExercise
    {
        private readonly IExerciseRepository _exerciseRepository;
        public GetExercise(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }
        public async Task<ExerciseModelOutput> Handle(
            GetExerciseInput request,
            CancellationToken cancellationToken)
        {
           var exercise = await _exerciseRepository.Get(request.Id, cancellationToken);
           return ExerciseModelOutput.FromExercise(exercise);
        }
    }
}
