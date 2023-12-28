using MekToolsReduxCore.Modules.ModulePreviews.Models;

namespace MekToolsReduxCore.Modules.ModulePreviews.Utils;

public static class EntityGeneratorUtils
{
  private const string FolderName = "Entities";

  public static ModuleDirectoryPreviewModel GenerateDirectoryPreviewModel(string entitySingularName)
  {
    var entitiesConfigurationFolder = new ModuleDirectoryPreviewModel
    {
      Name = FolderName,
      Files = new List<ModuleFilePreviewModel>
      {
        GenerateFilePreviewModel(entitySingularName)
      }
    };

    return entitiesConfigurationFolder;
  }

  public static ModuleFilePreviewModel GenerateFilePreviewModel(string entitySingularName)
  {
    return new ModuleFilePreviewModel { Name = $"{entitySingularName}.cs" };
  }
}