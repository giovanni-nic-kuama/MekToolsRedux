using MekToolsReduxCore.Modules.ModulePreviews.Dtos;
using MekToolsReduxCore.Modules.ModulePreviews.Models;
using MekToolsReduxCore.Modules.ModulePreviews.Utils;

namespace MekToolsReduxCore.Modules.ModulePreviews.Services;

public static class ModulePreviewService
{
  public static ModulePreviewModel GenerateModulePreview(ModulePreviewCreateDto dto)
  {
    var controllersFolder = ControllerGeneratorUtils
      .GenerateDirectoryPreviewModel(entityPluralName: dto.EntityPluralName);

    var dtosFolder = DtosGeneratorUtils
      .GenerateDirectoryPreviewModel(dto.EntitySingularName, dto.EnableUpsertDto);

    var entitiesFolder = EntityGeneratorUtils
      .GenerateDirectoryPreviewModel(entitySingularName: dto.EntitySingularName);

    var mappingFolders = MappingsGeneratorUtils
      .GenerateDirectoryPreviewModel(entitySingularName: dto.EntitySingularName);

    var servicesFolders = ServicesGeneratorUtils
      .GenerateDirectoryPreviewModel(entitySingularName: dto.EntitySingularName);

    var directories = new List<ModuleDirectoryPreviewModel>
    {
      entitiesFolder,
      mappingFolders,
      servicesFolders,
      controllersFolder,
      dtosFolder
    };

    if (dto.EnableValidators)
    {
      var validatorsFolder = ValidatorsGeneratorUtils
        .GenerateDirectoryPreviewModel(entitySingularName: dto.EntitySingularName,
          enableUpsertDto: dto.EnableUpsertDto);

      directories.Add(validatorsFolder);
    }

    if (dto.EnableEntityConfiguration)
    {
      var entitiesConfigurationFolder = EntityConfigurationGeneratorUtils
        .GenerateDirectoryPreviewModel(entitySingularName: dto.EntitySingularName);

      directories.Add(entitiesConfigurationFolder);
    }

    if (dto.EnableRepository)
    {
      var repositoriesFolders = RepositoryGeneratorUtils
        .GenerateDirectoryPreviewModel(entitySingularName: dto.EntitySingularName);

      directories.Add(repositoriesFolders);
    }

    directories = directories.OrderBy(e => e.Name).ToList();

    return new ModulePreviewModel
    {
      ModuleName = dto.EntityPluralName,
      Directories = directories
    };
  }
}