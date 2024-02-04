using MekToolsReduxCore.Modules.ModuleGenerators.Dtos;
using MekToolsReduxCore.Modules.ModuleGenerators.Utils;

namespace MekToolsReduxCore.Modules.ModuleGenerators.Repositories;

public static class ControllersFileRepository
{
  private const string ControllersTemplateFilename = "Controller.txt";
  private const string NamespaceNeedle = "---namespace-needle---";
  private const string ControllerNameNeedle = "---controller-name-needle---";
  
  public static void CreateControllersFolderAndGenerateTemplate(string modulePath, ModuleCreateDto dto)
  {
    var controllersDirectoryPath = CreateControllersFolder(modulePath);
    
    var controllersNamespace = NamespaceUtils.ComposeControllersNameSpace(dto.ProjectName, dto.EntityPluralName);
    var className = $"{dto.EntityPluralName}Controller";

    var controllerTemplate = GetControllerTemplate();

    controllerTemplate = controllerTemplate.Replace(NamespaceNeedle, $"namespace {controllersNamespace};");
    controllerTemplate = controllerTemplate.Replace(ControllerNameNeedle, className);
    
    TemplateFileRepository.WriteTemplate(controllerTemplate, controllersDirectoryPath, $"{className}.cs");
  }
  
  private static string CreateControllersFolder(string modulePath)
  {
    var entityDirectoryPath = Path.Combine(modulePath, "Controllers");
    Directory.CreateDirectory(entityDirectoryPath);

    return entityDirectoryPath;
  }
  
  private static string GetControllerTemplate()
  {
    return TemplateFileRepository.GetTemplateFileFromAssembly(ControllersTemplateFilename);
  }
}