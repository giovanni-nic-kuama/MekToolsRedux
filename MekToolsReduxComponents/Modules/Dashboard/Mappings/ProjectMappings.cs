using MekToolsReduxComponents.Modules.Dashboard.Models;
using MekToolsReduxCore.Modules.ModuleGenerators.Dtos;
using MekToolsReduxCore.Modules.ModulePreviews.Dtos;
using MekToolsReduxCore.Modules.ModulePreviews.Models;

namespace MekToolsReduxComponents.Modules.Dashboard.Mappings;

public static class ProjectMappings
{
  public static ModulePreviewCreateDto MapToDto(ProjectSettings projectSettings)
  {

    return new ModulePreviewCreateDto
    {
      EntitySingularName = projectSettings.EntityNameFormModel.EntitySingularName,
      EntityPluralName = projectSettings.EntityNameFormModel.EntityPluralName,
      EnableRepository = projectSettings.IsRepositoryEnabled,
      EnableValidators = projectSettings.AreValidatorsEnabled,
      EnableEntityConfiguration = projectSettings.IsEntityConfigurationEnabled,
      EnableUpsertDto = projectSettings.IsUpsertDtoEnabled,
    };
  }

  public static ModuleCreateDto MapToModuleCreateDto(ProjectSettings projectSettings, string modulesPath)
  {
    return new ModuleCreateDto
    {
     EntitySingularName = projectSettings.EntityNameFormModel.EntitySingularName,
     EntityPluralName = projectSettings.EntityNameFormModel.EntityPluralName,
     DestinationPath = modulesPath,
     EnableRepository = projectSettings.IsRepositoryEnabled,
     EnableValidators = projectSettings.AreValidatorsEnabled,
     EnableUpsertDto = projectSettings.IsUpsertDtoEnabled,
     EnableEntityConfiguration = projectSettings.IsEntityConfigurationEnabled
    };
  }
}