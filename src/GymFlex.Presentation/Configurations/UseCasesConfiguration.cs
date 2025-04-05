using GymFlex.Application.Interfaces;
using GymFlex.Application.UseCases.Exercise.GetExercise;
using GymFlex.Domain.Repositories;
using GymFlex.Infrastructure.Data;
using GymFlex.Infrastructure.Repositories;
using MediatR;

namespace GymFlex.Presentation.Configurations
{
    public static class UseCasesConfiguration
    {
        public static IServiceCollection AddUseCases(
            this IServiceCollection services
        )
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(GetExercise).Assembly);
            });
            services.AddRepositories();
            return services;
        }

        private static IServiceCollection AddRepositories(
            this IServiceCollection services
        )
        {
            services.AddTransient<IExerciseRepository, ExerciseRepository>();
            services.AddTransient<IExerciseSubstitutionRepository, ExerciseSubstitutionRepository>();
            services.AddTransient<IMuscleGroupRepository, MuscleGroupRepository>();
            services.AddTransient<ISpecificRegionRepository, SpecificRegionRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }   
}

