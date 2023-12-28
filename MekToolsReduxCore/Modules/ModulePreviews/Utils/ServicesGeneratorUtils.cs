using MekToolsReduxCore.Modules.ModulePreviews.Models;

namespace MekToolsReduxCore.Modules.ModulePreviews.Utils;

public static class ServicesGeneratorUtils
{
  private const string FolderName = "Services";

  public static ModuleDirectoryPreviewModel GenerateDirectoryPreviewModel(string entitySingularName)
  {
    var entitiesConfigurationFolder = new ModuleDirectoryPreviewModel
    {
      Name = FolderName,
      Files = GenerateFilePreviewModels(entitySingularName)
    };

    return entitiesConfigurationFolder;
  }

  public static List<ModuleFilePreviewModel> GenerateFilePreviewModels(string entitySingularName)
  {
    return new List<ModuleFilePreviewModel>()
      {
        new() { Name = $"I{entitySingularName}Service.cs" },
        new() { Name = $"{entitySingularName}Service.cs" },
      }.OrderByDescending(it => it.Name)
      .ToList();
  }
}