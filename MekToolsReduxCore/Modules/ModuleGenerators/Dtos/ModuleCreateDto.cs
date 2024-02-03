namespace MekToolsReduxCore.Modules.ModuleGenerators.Dtos;

public class ModuleCreateDto
{
  public string EntitySingularName { get; init; } = null!;

  public string EntityPluralName { get; init; } = null!;

  public string ModulesPath { get; init; } = null!;

  public string ProjectName { get; set; } = null!;

  public bool EnableValidators { get; init; }

  public bool EnableEntityConfiguration { get; init; }

  public bool EnableRepository { get; init; }

  public bool EnableUpsertDto { get; init; }
}