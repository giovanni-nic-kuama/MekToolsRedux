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
    var modulePath = Path.Combine(dto.DestinationPath, moduleCreateModel.ModuleName);

    // Step 2) Check if the directory already exists. If true, delete it
    if (Directory.Exists(modulePath))
    {
      Directory.Delete(modulePath, recursive: true);
    }

    Directory.CreateDirectory(modulePath);

    // Step 3) Create Entities Folder and Entity File
    CreateEntitiesFolderAndGenerateTemplate(modulePath, moduleCreateModel.EntityCreateModel);

    // Step 3) Create Controllers Folder and Controller file
    CreateControllersFolderAndGenerateTemplate(modulePath, moduleCreateModel.ControllerCreateModel);

    // Step 4) Create Mappings Folder and Mappings file
    CreateGenericTemplate(
      modulePath: modulePath,
      folderName: "Mappings",
      classNamespace: "com.kuama.todo",
      className: $"{dto.EntitySingularName}Mappings",
      fileName: $"{dto.EntitySingularName}Mappings.cs");

    // Step 5) Create Repositories Folder and Repository file
    CreateGenericTemplate(
      modulePath: modulePath,
      folderName: "Repositories",
      classNamespace: "com.kuama.todo",
      className: $"{dto.EntitySingularName}Repository",
      fileName: $"{dto.EntitySingularName}Repository.cs");

    // Step 5) Create Repositories Folder and Repository file
    CreateGenericTemplate(
      modulePath: modulePath,
      folderName: "Repositories",
      classNamespace: "com.kuama.todo",
      className: $"{dto.EntitySingularName}Repository",
      fileName: $"{dto.EntitySingularName}Repository.cs");

    // Step 6) Create Services Folder and Service file
    // TODO) Generate only interface file
    CreateGenericTemplate(
      modulePath: modulePath,
      folderName: "Services",
      classNamespace: "com.kuama.todo",
      className: $"{dto.EntitySingularName}Service",
      fileName: $"{dto.EntitySingularName}Service.cs");

    CreateGenericTemplate(
      modulePath: modulePath,
      folderName: "Dtos",
      classNamespace: "com.kuama.todo",
      className: $"{dto.EntitySingularName}ReadDto",
      fileName: $"{dto.EntitySingularName}ReadDto.cs");

    CreateGenericTemplate(
      modulePath: modulePath,
      folderName: "Validators",
      classNamespace: "com.kuama.todo",
      className: $"{dto.EntitySingularName}CreateDtoValidator",
      fileName: $"{dto.EntitySingularName}CreateDtoValidator.cs");
  }

  private static void CreateGenericTemplate(string modulePath, string folderName, string classNamespace,
    string className, string fileName)
  {
    // Create Entities Directory
    var entityDirectoryPath = Path.Combine(modulePath, folderName);
    Directory.CreateDirectory(entityDirectoryPath);

    // Read stored template to bytes
    var genericClassTemplate = TemplateFileRepository.GetGenericClassTemplate();

    var interpolatedTemplate =
      GenericClassInterpolator.InterpolateFile(genericClassTemplate, classNamespace, className);

    // Convert template to byte array
    var bytes = Encoding.ASCII.GetBytes(interpolatedTemplate);
    var currentFilePath = Path.Combine(entityDirectoryPath, fileName);

    // Write File
    File.WriteAllBytes(currentFilePath, bytes);
  }

  private static void CreateFileOnPath()
  {
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

  private static void CreateControllersFolderAndGenerateTemplate(string modulePath, ControllerCreateModel model)
  {
    // Create Entities Directory
    var controllersDirectoryPath = Path.Combine(modulePath, "Controllers");
    Directory.CreateDirectory(controllersDirectoryPath);

    // Read stored template to bytes
    var controllerTemplate = TemplateFileRepository.GetControllerTemplate();

    // TODO: interpolate template
    var interpolatedTemplate = ControllerInterpolator.InterpolateFile(controllerTemplate, model);

    // Convert template to byte array
    var bytes = Encoding.ASCII.GetBytes(interpolatedTemplate);
    var currentFilePath = Path.Combine(controllersDirectoryPath, model.FileName);

    // Write File
    File.WriteAllBytes(currentFilePath, bytes);
  }

  public static bool ValidatePath(string path)
  {
    var directoryExists = Directory.Exists(path);

    if (!directoryExists) return directoryExists;
    var hasWritePermission = HasWritePermission(path);

    return directoryExists && hasWritePermission;
  }

  private static bool HasWritePermission(string filePath)
  {
    try
    {
      File.Create(Path.Combine(filePath, "temp.txt")).Close();
      File.Delete(Path.Combine(filePath, "temp.txt"));
    }
    catch (UnauthorizedAccessException)
    {
      return false;
    }

    return true;
  }
}