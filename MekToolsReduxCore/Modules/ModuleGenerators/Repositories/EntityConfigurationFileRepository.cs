using MekToolsReduxCore.Modules.ModuleGenerators.Dtos;
using MekToolsReduxCore.Modules.ModuleGenerators.Utils;

namespace MekToolsReduxCore.Modules.ModuleGenerators.Repositories;

public static class EntityConfigurationFileRepository
{
  private const string EntityConfigurationFileName = "EntityConfiguration.txt";
  private const string EntityNamespaceNeedle = "---entity-namespace-needle---";
  private const string EntityConfigurationNamespaceNeedle = "---entities-configuration-namespace-needle---";
  private const string EntityNameNeedle = "---entity-name-needle---";
  
  public static void CreateEntitiesConfigurationFolderAndGenerateTemplate(string modulePath, ModuleCreateDto dto)
  {
    // Create Entities Directory
    var entityDirectoryPath = CreateEntitiesConfigurationFolder(modulePath);

    // Read stored template to bytes
    var entityTemplate = GetEntityConfigurationTemplate();

    // 1) Generate Entity NameSpace
    var entityNamespace = NamespaceUtils.ComposeEntityNameSpace(dto.ProjectName, dto.EntityPluralName);

    var entityConfigurationNamespace = NamespaceUtils
      .ComposeEntityConfigurationNameSpace(dto.ProjectName, dto.EntityPluralName);
    
    // 2) Check If Entity Configuration is needed
    var interpolatedTemplate = InterpolateEntityTemplateWithEntityConfigurationFile(
      template: entityTemplate, 
      entitySingularName: dto.EntitySingularName,
      entityNamespace: entityNamespace,
      entityConfigurationNamespace: entityConfigurationNamespace
      );

    // Write template to file
    TemplateFileRepository
      .WriteTemplate(interpolatedTemplate, entityDirectoryPath, $"{dto.EntitySingularName}EntityConfiguration.cs");
  }

  private static string InterpolateEntityTemplateWithEntityConfigurationFile(string template,
    string entitySingularName, string entityNamespace, string entityConfigurationNamespace)
  {
    var interpolatedFile = template.Replace(EntityNamespaceNeedle, entityNamespace);
    interpolatedFile = interpolatedFile.Replace(EntityConfigurationNamespaceNeedle, entityConfigurationNamespace);
    interpolatedFile = interpolatedFile.Replace(EntityConfigurationNamespaceNeedle, entityConfigurationNamespace);

    return interpolatedFile.Replace(EntityNameNeedle, entitySingularName);
  }

  private static string CreateEntitiesConfigurationFolder(string modulePath)
  {
    var entityDirectoryPath = Path.Combine(modulePath, "EntitiesConfigurations");
    Directory.CreateDirectory(entityDirectoryPath);

    return entityDirectoryPath;
  }

  private static string GetEntityConfigurationTemplate()
  {
    return TemplateFileRepository.GetTemplateFileFromAssembly(EntityConfigurationFileName);
  }
}