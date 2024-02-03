using MekToolsReduxCore.Modules.ModuleGenerators.Dtos;
using MekToolsReduxCore.Modules.ModuleGenerators.Utils;

namespace MekToolsReduxCore.Modules.ModuleGenerators.Repositories;

public static class ServiceFileRepository
{
  private const string GenericClassFileName = "GenericClass.txt";
  private const string NamespaceNeedle = "---namespace-needle---";
  private const string ClassNameNeedle = "---generic-class-name-needle---";

  public static void CreateServicesFolderAndGenerateTemplates(string modulePath, ModuleCreateDto dto)
  {
    var servicesDirectoryPath = CreateServicesFolder(modulePath);

    var genericClassTemplate = GetGenericClassTemplate();
    var serviceNamespace = NamespaceUtils.ComposeServiceNameSpace(dto.ProjectName, dto.EntityPluralName);

    GenerateServiceInterface(
      className: $"{dto.EntitySingularName}Service",
      servicesDirectoryPath: servicesDirectoryPath,
      servicesNamespace: serviceNamespace);


    GenerateService(
      className: $"{dto.EntitySingularName}Service",
      interfaceName: $"I{dto.EntitySingularName}Service",
      servicesDirectoryPath: servicesDirectoryPath,
      genericClassTemplate: genericClassTemplate,
      servicesNamespace: serviceNamespace);
  }

  private static void GenerateService(string className, string interfaceName, string servicesDirectoryPath,
    string genericClassTemplate, string servicesNamespace)
  {
    var interpolatedTemplate = genericClassTemplate;
    interpolatedTemplate = interpolatedTemplate.Replace(NamespaceNeedle, $"namespace {servicesNamespace};");
    interpolatedTemplate = interpolatedTemplate.Replace(ClassNameNeedle, className + " : " + interfaceName);

    TemplateFileRepository.WriteTemplate(interpolatedTemplate, servicesDirectoryPath, $"{className}.cs");
  }

  private static void GenerateServiceInterface(string className, string servicesDirectoryPath, string servicesNamespace)
  {

    var interpolatedTemplate = $"namespace {servicesNamespace};\n";
    interpolatedTemplate += "\n";
    interpolatedTemplate += $"public interface I{className}\n";
    interpolatedTemplate += "{";
    interpolatedTemplate += "\n    \n";
    interpolatedTemplate += "}";
    interpolatedTemplate += "\n";

    TemplateFileRepository.WriteTemplate(interpolatedTemplate, servicesDirectoryPath, $"I{className}.cs");
  }

  private static string CreateServicesFolder(string modulePath)
  {
    var entityDirectoryPath = Path.Combine(modulePath, "Services");
    Directory.CreateDirectory(entityDirectoryPath);

    return entityDirectoryPath;
  }

  private static string GetGenericClassTemplate()
  {
    return TemplateFileRepository.GetTemplateFileFromAssembly(GenericClassFileName);
  }
}