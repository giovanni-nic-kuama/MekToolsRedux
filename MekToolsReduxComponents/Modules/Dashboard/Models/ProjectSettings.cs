namespace MekToolsReduxComponents.Modules.Dashboard.Models;

public record ProjectSettings
{
  public bool IsUpsertDtoEnabled { get; set; }

  public bool IsRepositoryEnabled { get; set; }

  public bool AreValidatorsEnabled { get; set; }

  public bool IsEntityConfigurationEnabled { get; set; }
}