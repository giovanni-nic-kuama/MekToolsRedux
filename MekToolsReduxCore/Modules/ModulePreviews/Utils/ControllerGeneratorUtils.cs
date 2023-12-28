using MekToolsReduxCore.Modules.ModulePreviews.Models;

namespace MekToolsReduxCore.Modules.ModulePreviews.Utils;

public static class ControllerGeneratorUtils
{
  private const string FolderName = "Controllers";

  public static ModuleDirectoryPreviewModel GenerateDirectoryPreviewModel(string entityPluralName)
  {
    var entitiesConfigurationFolder = new ModuleDirectoryPreviewModel
    {
      Name = FolderName,
      Files = new List<ModuleFilePreviewModel>
      {
        GenerateFilePreviewModel(entityPluralName)
      }
    };

    return entitiesConfigurationFolder;
  }

  public static ModuleFilePreviewModel GenerateFilePreviewModel(string entityPluralName)
  {
    return new ModuleFilePreviewModel { Name = $"{entityPluralName}Repository.cs" };
  }
}