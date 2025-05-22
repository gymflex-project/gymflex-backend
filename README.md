# GymFlex Backend

## 📋 Sobre o Projeto
GymFlex é uma aplicação backend desenvolvida em C# focada no gerenciamento de exercícios físicos e suas substituições. O projeto implementa uma arquitetura robusta seguindo princípios SOLID, DDD e Clean Architecture.

## 🏗️ Arquitetura

### SOLID

#### Single Responsibility Principle (SRP)
- Cada classe possui uma única responsabilidade bem definida
- Separação clara entre entidades, serviços e repositórios
- Validações de domínio isoladas em suas respectivas classes

#### Open/Closed Principle (OCP)
- Sistema extensível através de interfaces e classes abstratas
- Configurações de entidades separadas em classes específicas
- Implementações concretas podem ser adicionadas sem modificar código existente

### Domain-Driven Design (DDD)

#### 🏢 Camadas
- **Domínio**: Regras de negócio centrais
- **Aplicação**: Casos de uso e orquestração
- **Infraestrutura**: Implementações técnicas
- **Presentation**: Interface com usuário

#### 📦 Componentes Principais
- Entidades
- Agregados
- Repositórios
- Serviços de Domínio

### Clean Architecture

#### 🔄 Fluxo de Dependências
- Dependências apontam para o centro (domínio)
- Camadas externas dependem de abstrações
- Inversão de dependência através de interfaces

## 🛠️ Tecnologias

- .NET 9.0
- Entity Framework Core
- PostgreSQL
- Identity Framework
- MediatR
- FluentValidation
- Docker

## ⚙️ Configuração

### Pré-requisitos
- .NET 9.0 SDK
- Docker Desktop
- PostgreSQL (se executado localmente)

### Variáveis de Ambiente
```plaintext
DATABASE_CONNECTION=
JWT_SECRET_KEY=
```
# Padröes Implementados

## SOLID

### Single Responsibility Principle

**Arquivo:** `src/GymFlex.Infrastructure/Repositories/ExerciseRepository.cs`
A classe `ExerciseRepository` tem única responsabilidade de acessar e persistir dados de exercícios, sem envolver lógica de negócio ou orquestração de casos de uso.

```csharp
public class ExerciseRepository : IExerciseRepository
{
    private readonly ApplicationDbContext _context;
    private DbSet<Exercise> _exercises => _context.Set<Exercise>();

    public ExerciseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Exercise> Get(Guid id, CancellationToken cancellationToken)
    {
        var exercise = await _exercises
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        NotFoundException.ThrowIfNull(exercise, $"Exercise '{id}' not found.");
        return exercise!;
    }
    
    public async Task Insert(Exercise aggregate, CancellationToken cancellationToken) 
        => await _exercises.AddAsync(aggregate, cancellationToken);
    
    public Task Delete(Exercise aggregate, CancellationToken _) 
        => Task.FromResult(_exercises.Remove(aggregate));
    
    public Task Update(Exercise aggregate, CancellationToken _) 
        => Task.FromResult(_exercises.Update(aggregate));
}
```

## DDD

### Repositório

**Arquivo:** `src/GymFlex.Domain/Repositories/IExerciseRepository.cs`
Define o contrato de persistência para a entidade `Exercise`, mantendo a camada de domínio isolada de tecnologias de acesso a dados.

```csharp
public interface IExerciseRepository
{
    Task<Exercise> Get(Guid id, CancellationToken cancellationToken);
    Task Insert(Exercise aggregate, CancellationToken cancellationToken);
    Task Delete(Exercise aggregate, CancellationToken cancellationToken);
    Task Update(Exercise aggregate, CancellationToken cancellationToken);
}
```

## Clean Architecture

### Inversão de Dependência

**Arquivo:** `src/GymFlex.Application/Services/ExerciseService.cs`
A camada de aplicação depende das abstrações (`IExerciseRepository`) definidas na camada de domínio, sem referenciar implementações concretas da infraestrutura.

```csharp
public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _repository;

    public ExerciseService(IExerciseRepository repository)
    {
        _repository = repository;
    }

    public async Task<ExerciseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _repository.Get(id, cancellationToken);
        return _mapper.Map<ExerciseDto>(entity);
    }

    public async Task CreateAsync(CreateExerciseDto dto, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Exercise>(dto);
        await _repository.Insert(entity, cancellationToken);
    }
    // ...
}
```
