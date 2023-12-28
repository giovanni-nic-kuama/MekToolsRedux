using MekToolsReduxComponents.Modules.Main.Models;
using MekToolsReduxCore.Modules.ModulePreviews.Dtos;

namespace MekToolsReduxComponents.Modules.Main.Mappings;

public static class ModulePreviewModelMappings
{
  public static ModulePreviewCreateDto Map(string entitySingularName, string entityPluralName,
    AdditionalSettingsFormModel additionalSettings)
  {
    return new ModulePreviewCreateDto
    {
      EntitySingularName = entitySingularName,
      EntityPluralName = entityPluralName,
      EnableUpsertDto = additionalSettings.EnableUpsertDto,
      EnableEntityConfiguration = additionalSettings.EnableEntityConfiguration,
      EnableRepository = additionalSettings.EnableRepository,
      EnableValidators = additionalSettings.EnableValidators
    };
  }
}