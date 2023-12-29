using System.Reflection;
using MekToolsReduxCore.Modules.ModuleGenerators.Exceptions;

namespace MekToolsReduxCore.Modules.ModuleGenerators.Repositories;

public static class TemplateFileRepository
{
  private const string ProjectNamespace = "MekToolsReduxCore.Resources";

  private const string ControllerFileName = "Controller.txt";
  private const string DtoFileName = "Dto.txt";
  private const string EntityFileName = "Entity.txt";
  private const string EntityConfigurationFileName = "EntityConfiguration.txt";
  private const string MappingsFileName = "Mappings.txt";
  private const string RepositoryFileName = "Repository.txt";
  private const string ServiceInterfaceFileName = "IService.txt";
  private const string ServiceFileName = "Service.txt";
  private const string GenericClassFileName = "GenericClass.txt";

  public static string GetControllerTemplate()
  {
    return GetTemplateFileFromAssembly(ControllerFileName);
  }

  public static string GetDtoTemplate()
  {
    return GetTemplateFileFromAssembly(DtoFileName);
  }

  public static string GetEntityTemplate()
  {
    return GetTemplateFileFromAssembly(EntityFileName);
  }

  public static string GetEntityConfigurationTemplate()
  {
    return GetTemplateFileFromAssembly(EntityConfigurationFileName);
  }

  public static string GetMappingsTemplate()
  {
    return GetTemplateFileFromAssembly(MappingsFileName);
  }

  public static string GetRepositoryTemplate()
  {
    return GetTemplateFileFromAssembly(RepositoryFileName);
  }

  public static string GetServiceInterfaceTemplate()
  {
    return GetTemplateFileFromAssembly(ServiceInterfaceFileName);
  }

  public static string GetServiceTemplate()
  {
    return GetTemplateFileFromAssembly(ServiceFileName);
  }

  public static string GetGenericClassTemplate()
  {
    return GetTemplateFileFromAssembly(GenericClassFileName);
  }

  // TODO: validators

  private static string GetTemplateFileFromAssembly(string fileName)
  {
    var assembly = Assembly.GetExecutingAssembly();
    var resourceName = ComposeFileNameFromAssembly(fileName);
    using var stream = assembly.GetManifestResourceStream(resourceName);

    if (stream == null)
    {
      throw new TemplateNotFoundException();
    }

    using var reader = new StreamReader(stream);
    return reader.ReadToEnd();
  }

  private static string ComposeFileNameFromAssembly(string filename)
  {
    return $"{ProjectNamespace}.{filename}";
  }
}