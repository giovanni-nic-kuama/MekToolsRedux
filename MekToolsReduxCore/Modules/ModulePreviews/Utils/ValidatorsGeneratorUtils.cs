using MekToolsReduxCore.Modules.ModulePreviews.Models;

namespace MekToolsReduxCore.Modules.ModulePreviews.Utils;

public static class ValidatorsGeneratorUtils
{
  private const string FolderName = "Validators";
  private const string CreateDtoValidatorPostfix = "CreateDtoValidator";
  private const string UpdateDtoValidatorPostfix = "UpdateDtoValidator";
  private const string UpsertDtoValidatorPostfix = "UpsertDtoValidator";

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
        new()
        {
          Name = GenerateDtoFileName(entitySingularName: entitySingularName, dtoPostfix: UpsertDtoValidatorPostfix)
        },
      }.OrderByDescending(e => e.Name).ToList();
    }

    return new List<ModuleFilePreviewModel>()
    {
      new()
      {
        Name = GenerateDtoFileName(entitySingularName: entitySingularName, dtoPostfix: CreateDtoValidatorPostfix)
      },
      new()
      {
        Name = GenerateDtoFileName(entitySingularName: entitySingularName, dtoPostfix: UpdateDtoValidatorPostfix)
      },
    }.OrderByDescending(e => e.Name).ToList();
  }

  private static string GenerateDtoFileName(string entitySingularName, string dtoPostfix)
  {
    return $"{entitySingularName}{dtoPostfix}.cs";
  }
}