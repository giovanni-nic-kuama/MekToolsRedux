using MekToolsReduxCore.Modules.ModulePreviews.Models;

namespace MekToolsReduxCore.Modules.ModulePreviews.Utils;

public static class DtosGeneratorUtils
{
  private const string FolderName = "Dtos";
  private const string ReadDtoPostfix = "ReadDto";
  private const string CreateDtoPostfix = "CreateDto";
  private const string UpdateDtoPostfix = "UpdateDto";
  private const string UpsertDtoPostfix = "UpsertDto";

  public static ModuleDirectoryPreviewModel GenerateDirectoryPreviewModel(string entitySingularName,
    bool enableUpsertDto)
  {
    var entitiesConfigurationFolder = new ModuleDirectoryPreviewModel
    {
      Name = FolderName,
      Files = GenerateFilePreviewModels(entitySingularName, enableUpsertDto)
    };

    return entitiesConfigurationFolder;
  }

  public static List<ModuleFilePreviewModel> GenerateFilePreviewModels(string entitySingularName, bool enableUpsertDto)
  {
    if (enableUpsertDto)
    {
      return new List<ModuleFilePreviewModel>()
      {
        new() { Name = GenerateDtoFileName(entitySingularName: entitySingularName, dtoPostfix: UpsertDtoPostfix) },
        new() { Name = GenerateDtoFileName(entitySingularName: entitySingularName, dtoPostfix: ReadDtoPostfix) }
      }.OrderByDescending(e => e.Name).ToList();
    }

    return new List<ModuleFilePreviewModel>()
    {
      new() { Name = GenerateDtoFileName(entitySingularName: entitySingularName, dtoPostfix: CreateDtoPostfix) },
      new() { Name = GenerateDtoFileName(entitySingularName: entitySingularName, dtoPostfix: UpdateDtoPostfix) },
      new() { Name = GenerateDtoFileName(entitySingularName: entitySingularName, dtoPostfix: ReadDtoPostfix) }
    }.OrderByDescending(e => e.Name).ToList();
  }

  private static string GenerateDtoFileName(string entitySingularName, string dtoPostfix)
  {
    return $"{entitySingularName}{dtoPostfix}.cs";
  }
}