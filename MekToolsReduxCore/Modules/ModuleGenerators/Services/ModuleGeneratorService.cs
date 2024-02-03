using System.Text;
using MekToolsReduxCore.Modules.ModuleGenerators.Dtos;
using MekToolsReduxCore.Modules.ModuleGenerators.Interpolators;
using MekToolsReduxCore.Modules.ModuleGenerators.Mappings;
using MekToolsReduxCore.Modules.ModuleGenerators.Models;
using MekToolsReduxCore.Modules.ModuleGenerators.Repositories;

namespace MekToolsReduxCore.Modules.ModuleGenerators.Services;

public static class ModuleGeneratorService
{
  public static void GenerateModule(ModuleCreateDto dto)
  {
    var moduleCreateModel = ModuleMappings.Map(dto);

    // Step 1) Generate Module main folder
    var modulePath = Path.Combine(dto.ModulesPath, moduleCreateModel.ModuleName);

    // Step 2) Check if the directory already exists. If true, delete it
    if (Directory.Exists(modulePath))
    {
      Directory.Delete(modulePath, recursive: true);
    }

    Directory.CreateDirectory(modulePath);

    // Step 3) Create Entities Folder and Entity File
    CreateEntitiesFolderAndGenerateTemplate(modulePath, moduleCreateModel.EntityCreateModel);
  }

  private static void CreateEntitiesFolderAndGenerateTemplate(string modulePath, EntityCreateModel model)
  {
    // Create Entities Directory
    var entityDirectoryPath = Path.Combine(modulePath, "Entities");
    Directory.CreateDirectory(entityDirectoryPath);

    // Read stored template to bytes
    var entityTemplate = TemplateFileRepository.GetEntityTemplate();

    var interpolatedTemplate = EntityInterpolator.InterpolateFile(entityTemplate, model);

    // Convert template to byte array
    var bytes = Encoding.ASCII.GetBytes(interpolatedTemplate);
    var currentFilePath = Path.Combine(entityDirectoryPath, model.FileName);

    // Write File
    File.WriteAllBytes(currentFilePath, bytes);
  }
}