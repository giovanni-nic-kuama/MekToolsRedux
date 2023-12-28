namespace MekToolsReduxCore.Modules.ModulePreviews.Dtos;

public record ModulePreviewCreateDto
{
  public string EntitySingularName { get; init; } = null!;

  public string EntityPluralName { get; init; } = null!;

  public bool EnableValidators { get; init; }

  public bool EnableEntityConfiguration { get; init; }

  public bool EnableRepository { get; init; }

  public bool EnableUpsertDto { get; init; }
}