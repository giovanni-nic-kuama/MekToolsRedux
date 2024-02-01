using MekToolsReduxComponents.Modules.Dashboard.Forms;

namespace MekToolsReduxComponents.Modules.Dashboard.Models;

public record ProjectSettings
{
  public bool IsUpsertDtoEnabled { get; set; }

  public bool IsRepositoryEnabled { get; set; }

  public bool AreValidatorsEnabled { get; set; }

  public bool IsEntityConfigurationEnabled { get; set; }

  public EntityNameFormModel EntityNameFormModel { get; set; } = new();
}