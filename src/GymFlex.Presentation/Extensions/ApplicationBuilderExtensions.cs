using GymFlex.Domain.Entities;
using GymFlex.Domain.Enums;
using GymFlex.Infrastructure.Data.Context;

namespace GymFlex.Presentation.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseSeeder(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                Console.WriteLine("Populando banco de dados...");

                if (!context.MuscleGroups.Any())
                {
                    // Dicionário com MuscleGroups e suas SpecificRegions
                    var groupsWithRegions = new Dictionary<string, List<string>>
                    {
                        ["Peito"] = new() { "Peitoral Superior", "Peitoral Médio", "Peitoral Inferior" },
                        ["Costas"] = new() { "Dorsal", "Trapézio", "Lombar" },
                        ["Pernas"] = new() { "Quadríceps", "Posterior de Coxa", "Panturrilha", "Adutores", "Abdutores" },
                        ["Ombros"] = new() { "Deltoide Anterior", "Deltoide Lateral", "Deltoide Posterior", "Manguito Rotador" },
                        ["Braços"] = new() { "Bíceps", "Tríceps", "Antebraço" },
                        ["Abdômen"] = new() { "Abdominais Superiores", "Abdominais Inferiores", "Oblíquos" },
                        ["Pescoço"] = new() { "Trapézio Superior", "Esternocleidomastoideo", "Flexores Profundos do Pescoço" },
                        ["Glúteos"] = new() { "Glúteo Máximo", "Glúteo Médio", "Glúteo Mínimo" },
                    };

                    var muscleGroups = new List<MuscleGroup>();

                    // Criar MuscleGroups
                    foreach (var groupName in groupsWithRegions.Keys)
                    {
                        var group = new MuscleGroup(groupName);
                        muscleGroups.Add(group);
                        context.MuscleGroups.Add(group);
                    }

                    context.SaveChanges();

                    // Criar SpecificRegions
                    var specificRegions = new List<SpecificRegion>();

                    foreach (var group in muscleGroups)
                    {
                        if (groupsWithRegions.TryGetValue(group.Name, out var regions))
                        {
                            foreach (var region in regions)
                            {
                                var specificRegion = new SpecificRegion(region, group.Id);
                                specificRegions.Add(specificRegion);
                                context.SpecificRegions.Add(specificRegion);
                            }
                        }
                    }

                    context.SaveChanges();

                    // Captura de IDs para criação de exercícios
                    var peito = muscleGroups.First(g => g.Name == "Peito").Id;
                    var peitoSuperior = specificRegions.First(r => r.Name == "Peitoral Superior").Id;
                    var peitoMedio = specificRegions.First(r => r.Name == "Peitoral Médio").Id;
                    var peitoInferior = specificRegions.First(r => r.Name == "Peitoral Inferior").Id;

                    var costas = muscleGroups.First(g => g.Name == "Costas").Id;
                    var dorsal = specificRegions.First(r => r.Name == "Dorsal").Id;
                    var trapezio = specificRegions.First(r => r.Name == "Trapézio").Id;
                    var lombar = specificRegions.First(r => r.Name == "Lombar").Id;

                    var pernas = muscleGroups.First(g => g.Name == "Pernas").Id;
                    var quadriceps = specificRegions.First(r => r.Name == "Quadríceps").Id;
                    var posterior = specificRegions.First(r => r.Name == "Posterior de Coxa").Id;
                    var panturrilha = specificRegions.First(r => r.Name == "Panturrilha").Id;

                    var ombros = muscleGroups.First(g => g.Name == "Ombros").Id;
                    var deltoideAnterior = specificRegions.First(r => r.Name == "Deltoide Anterior").Id;
                    var deltoideLateral = specificRegions.First(r => r.Name == "Deltoide Lateral").Id;
                    var deltoidePosterior = specificRegions.First(r => r.Name == "Deltoide Posterior").Id;

                    var bracos = muscleGroups.First(g => g.Name == "Braços").Id;
                    var biceps = specificRegions.First(r => r.Name == "Bíceps").Id;
                    var triceps = specificRegions.First(r => r.Name == "Tríceps").Id;
                    var antebraco = specificRegions.First(r => r.Name == "Antebraço").Id;

                    var abdomen = muscleGroups.First(g => g.Name == "Abdômen").Id;
                    var abdSup = specificRegions.First(r => r.Name == "Abdominais Superiores").Id;
                    var abdInf = specificRegions.First(r => r.Name == "Abdominais Inferiores").Id;
                    var obliquos = specificRegions.First(r => r.Name == "Oblíquos").Id;

                    // Criação dos Exercícios
                    context.Exercises.AddRange(
                        new Exercise("Flexão de Braço", peito, peitoMedio, DifficultyLevel.Medium,
                            "Exercício com peso corporal para peitoral.", ExerciseCategory.Strength,
                            EquipmentType.BodyWeight),
                        new Exercise("Supino Inclinado com Halteres", peito, peitoSuperior, DifficultyLevel.Medium,
                            "Trabalha o peitoral superior com halteres.", ExerciseCategory.Strength,
                            EquipmentType.Dumbbell),
                        new Exercise("Cross Over no Cabo", peito, peitoMedio, DifficultyLevel.Medium,
                            "Isolamento do peitoral com cabos.", ExerciseCategory.Strength, EquipmentType.Cable),
                        new Exercise("Pullover com Halteres", peito, peitoInferior, DifficultyLevel.Medium,
                            "Trabalha peitoral e dorsais com halteres.", ExerciseCategory.Functional,
                            EquipmentType.Dumbbell),

                        new Exercise("Remada Curvada com Barra", costas, dorsal, DifficultyLevel.Hard,
                            "Exercício composto para costas.", ExerciseCategory.Strength, EquipmentType.Barbell),
                        new Exercise("Puxada na Frente com Pegada Aberta", costas, dorsal, DifficultyLevel.Medium,
                            "Foco nos dorsais com máquina.", ExerciseCategory.Strength, EquipmentType.Machine),
                        new Exercise("Remada Unilateral com Halter", costas, dorsal, DifficultyLevel.Medium,
                            "Trabalho unilateral das costas.", ExerciseCategory.Strength, EquipmentType.Dumbbell),
                        new Exercise("Levantamento Terra", costas, lombar, DifficultyLevel.Hard,
                            "Movimento completo para lombar e posteriores.", ExerciseCategory.Strength,
                            EquipmentType.Barbell),

                        new Exercise("Leg Press 45°", pernas, quadriceps, DifficultyLevel.Medium,
                            "Exercício composto para pernas com máquina.", ExerciseCategory.Strength,
                            EquipmentType.Machine),
                        new Exercise("Cadeira Extensora", pernas, quadriceps, DifficultyLevel.Easy,
                            "Isolamento de quadríceps.", ExerciseCategory.Strength, EquipmentType.Machine),
                        new Exercise("Cadeira Flexora", pernas, posterior, DifficultyLevel.Medium,
                            "Isolamento dos posteriores de coxa.", ExerciseCategory.Strength, EquipmentType.Machine),
                        new Exercise("Panturilha no Leg Press", pernas, panturrilha, DifficultyLevel.Easy,
                            "Panturrilhas com carga no leg press.", ExerciseCategory.Strength, EquipmentType.Machine),

                        new Exercise("Elevação Lateral com Halteres", ombros, deltoideLateral, DifficultyLevel.Medium,
                            "Isolamento do deltoide lateral.", ExerciseCategory.Strength, EquipmentType.Dumbbell),
                        new Exercise("Desenvolvimento com Barra", ombros, deltoideAnterior, DifficultyLevel.Hard,
                            "Exercício composto para ombros.", ExerciseCategory.Strength, EquipmentType.Barbell),
                        new Exercise("Remada Alta", ombros, deltoidePosterior, DifficultyLevel.Medium,
                            "Trabalha ombros e trapézio.", ExerciseCategory.Strength, EquipmentType.Barbell),

                        new Exercise("Rosca Direta", bracos, biceps, DifficultyLevel.Medium,
                            "Clássico para bíceps com barra.", ExerciseCategory.Strength, EquipmentType.Barbell),
                        new Exercise("Rosca Alternada", bracos, biceps, DifficultyLevel.Medium,
                            "Bíceps com halteres de forma alternada.", ExerciseCategory.Strength,
                            EquipmentType.Dumbbell),
                        new Exercise("Tríceps Testa", bracos, triceps, DifficultyLevel.Medium,
                            "Trabalha a longa cabeça do tríceps.", ExerciseCategory.Strength, EquipmentType.Barbell),
                        new Exercise("Tríceps Corda no Pulley", bracos, triceps, DifficultyLevel.Medium,
                            "Trabalha tríceps com cabos.", ExerciseCategory.Strength, EquipmentType.Cable),
                        new Exercise("Rosca de Punho", bracos, antebraco, DifficultyLevel.Easy,
                            "Isolamento dos antebraços.", ExerciseCategory.Strength, EquipmentType.Dumbbell),

                        new Exercise("Prancha Abdominal", abdomen, abdSup, DifficultyLevel.Medium,
                            "Estabilização do core sem movimento.", ExerciseCategory.Mobility,
                            EquipmentType.BodyWeight),
                        new Exercise("Elevação de Pernas na Barra Fixa", abdomen, abdInf, DifficultyLevel.Medium,
                            "Trabalha abdominal inferior com peso corporal.", ExerciseCategory.Strength,
                            EquipmentType.BodyWeight),
                        new Exercise("Abdominal Oblíquo no Banco", abdomen, obliquos, DifficultyLevel.Medium,
                            "Foco nos músculos oblíquos.", ExerciseCategory.Strength, EquipmentType.Machine)
                    );

                    context.SaveChanges();

                    Console.WriteLine("Seed de Exercícios concluído com sucesso.");
                }
                
                // Seção para popular a tabela de ExerciseSubstitution
                if (!context.ExerciseSubstitutions.Any())
                {
                    // Recupera IDs dos exercícios previamente criados
                    var flexaoDeBracoId = context.Exercises.First(e => e.Name == "Flexão de Braço").Id;
                    var supinoInclinadoId = context.Exercises.First(e => e.Name == "Supino Inclinado com Halteres").Id;
                    var crossOverId = context.Exercises.First(e => e.Name == "Cross Over no Cabo").Id;
                    var remadaCurvadaId = context.Exercises.First(e => e.Name == "Remada Curvada com Barra").Id;
                    var puxadaId = context.Exercises.First(e => e.Name == "Puxada na Frente com Pegada Aberta").Id;
                    var remadaUnilateralId = context.Exercises.First(e => e.Name == "Remada Unilateral com Halter").Id;
                    var levantamentoTerraId = context.Exercises.First(e => e.Name == "Levantamento Terra").Id;
                    var legPressId = context.Exercises.First(e => e.Name == "Leg Press 45°").Id;
                    var cadeiraExtensoraId = context.Exercises.First(e => e.Name == "Cadeira Extensora").Id;
                    var cadeiraFlexoraId = context.Exercises.First(e => e.Name == "Cadeira Flexora").Id;
                    var elevacaoLateralId = context.Exercises.First(e => e.Name == "Elevação Lateral com Halteres").Id;
                    var desenvolvimentoId = context.Exercises.First(e => e.Name == "Desenvolvimento com Barra").Id;
                    var remadaAltaId = context.Exercises.First(e => e.Name == "Remada Alta").Id;
                    var roscaDiretaId = context.Exercises.First(e => e.Name == "Rosca Direta").Id;
                    var roscaAlternadaId = context.Exercises.First(e => e.Name == "Rosca Alternada").Id;
                    var tricepsTestaId = context.Exercises.First(e => e.Name == "Tríceps Testa").Id;
                    var tricepsCordaId = context.Exercises.First(e => e.Name == "Tríceps Corda no Pulley").Id;
                    var pranchaId = context.Exercises.First(e => e.Name == "Prancha Abdominal").Id;
                    var elevacaoPernasId = context.Exercises.First(e => e.Name == "Elevação de Pernas na Barra Fixa").Id;
                    var abdominalObliquoId = context.Exercises.First(e => e.Name == "Abdominal Oblíquo no Banco").Id;

                    // Criação das substituições de exercícios (30 registros)
                    var exerciseSubstitutions = new List<ExerciseSubstitution>
                    {
                        new ExerciseSubstitution(EquivalenceLevel.High, "Substituição similar para peito.", flexaoDeBracoId, supinoInclinadoId),
                        new ExerciseSubstitution(EquivalenceLevel.Medium, "Alternativa para variação de peito.", flexaoDeBracoId, crossOverId),
                        new ExerciseSubstitution(EquivalenceLevel.High, "Substituição para costas, ambos focam nos dorsais.", remadaCurvadaId, puxadaId),
                        new ExerciseSubstitution(EquivalenceLevel.Medium, "Alternativa unilateral para costas.", remadaUnilateralId, levantamentoTerraId),
                        new ExerciseSubstitution(EquivalenceLevel.Medium, "Alternativa para treino de quadríceps.", legPressId, cadeiraExtensoraId),
                        new ExerciseSubstitution(EquivalenceLevel.High, "Substituição para ombros, focando deltoides.", elevacaoLateralId, desenvolvimentoId),
                        new ExerciseSubstitution(EquivalenceLevel.High, "Opção alternativa para bíceps.", roscaDiretaId, roscaAlternadaId),
                        new ExerciseSubstitution(EquivalenceLevel.High, "Alternativa para treino de tríceps.", tricepsTestaId, tricepsCordaId),
                        new ExerciseSubstitution(EquivalenceLevel.Medium, "Alternativa para treino do core.", pranchaId, elevacaoPernasId),
                        new ExerciseSubstitution(EquivalenceLevel.Medium, "Opção para treino de oblíquos.", abdominalObliquoId, pranchaId),

                        new ExerciseSubstitution(EquivalenceLevel.Medium, "Substituição complementar para peito, variante.", supinoInclinadoId, crossOverId),
                        new ExerciseSubstitution(EquivalenceLevel.High, "Opção extra para peito.", flexaoDeBracoId, supinoInclinadoId),
                        new ExerciseSubstitution(EquivalenceLevel.Low, "Substituição experimental para peito.", crossOverId, supinoInclinadoId),
                        new ExerciseSubstitution(EquivalenceLevel.High, "Substituição avançada para costas.", remadaCurvadaId, remadaUnilateralId),
                        new ExerciseSubstitution(EquivalenceLevel.Medium, "Alternativa dinâmica para costas.", puxadaId, remadaUnilateralId),
                        new ExerciseSubstitution(EquivalenceLevel.Medium, "Substituição para treino de costas completa.", remadaCurvadaId, levantamentoTerraId),
                        new ExerciseSubstitution(EquivalenceLevel.Low, "Alternativa leve para treino de pernas.", cadeiraExtensoraId, legPressId),
                        new ExerciseSubstitution(EquivalenceLevel.High, "Opção robusta para treino de pernas.", legPressId, cadeiraFlexoraId),
                        new ExerciseSubstitution(EquivalenceLevel.Medium, "Alternativa para treino de pernas, ênfase em posteriores.", cadeiraExtensoraId, cadeiraFlexoraId),
                        new ExerciseSubstitution(EquivalenceLevel.High, "Substituição para treino de ombros, variante extra.", elevacaoLateralId, desenvolvimentoId),
                        
                        new ExerciseSubstitution(EquivalenceLevel.Low, "Substituição leve para treino de ombros.", remadaAltaId, desenvolvimentoId),
                        new ExerciseSubstitution(EquivalenceLevel.Medium, "Alternativa para treino de tríceps, variante 2.", tricepsTestaId, tricepsCordaId),
                        new ExerciseSubstitution(EquivalenceLevel.High, "Substituição para treino de bíceps, variante extra.", roscaDiretaId, roscaAlternadaId),
                        new ExerciseSubstitution(EquivalenceLevel.Medium, "Alternativa para treino do core, variante.", pranchaId, elevacaoPernasId),
                        new ExerciseSubstitution(EquivalenceLevel.Low, "Substituição para treino de oblíquos, variante extra.", abdominalObliquoId, pranchaId),
                        new ExerciseSubstitution(EquivalenceLevel.Medium, "Opção para treino de peito, variante extra.", crossOverId, supinoInclinadoId),
                        new ExerciseSubstitution(EquivalenceLevel.High, "Substituição robusta para peito, opção extra.", supinoInclinadoId, flexaoDeBracoId),
                        new ExerciseSubstitution(EquivalenceLevel.Medium, "Alternativa para treino de costas, opção extra.", remadaUnilateralId, levantamentoTerraId),
                        new ExerciseSubstitution(EquivalenceLevel.Low, "Substituição leve para treino de costas, opção extra.", puxadaId, remadaCurvadaId),
                        new ExerciseSubstitution(EquivalenceLevel.High, "Substituição para treino de tríceps, opção robusta.", tricepsTestaId, tricepsCordaId)
                    };

                    context.ExerciseSubstitutions.AddRange(exerciseSubstitutions);
                    context.SaveChanges();

                    Console.WriteLine("Seed de Substituições de Exercícios concluído com sucesso.");
                }

            }

            return app;
        }
    }
}
