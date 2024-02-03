using MekToolsReduxCore.Modules.ModuleGenerators.Dtos;
using MekToolsReduxCore.Modules.ModuleGenerators.Utils;

namespace MekToolsReduxCore.Modules.ModuleGenerators.Repositories;

public static class EntityFileRepository
{
  private const string EntityTemplateFileName = "Entity.txt";
  private const string EntityFileSetupNeedle = "---entity-file-setup-needle---";
  private const string EntityNameNeedle = "---entity-name-needle---";

  public static void CreateEntitiesFolderAndGenerateTemplate(string modulePath, ModuleCreateDto dto)
  {
    // Create Entities Directory
    var entityDirectoryPath = CreateEntitiesFolder(modulePath);

    // Read stored template to bytes
    var entityTemplate = GetEntityTemplate();

    // 1) Generate Entity NameSpace
    var entityNamespace = NamespaceUtils.ComposeEntityNameSpace(dto.ProjectName, dto.EntityPluralName);

    // 2) Check If Entity Configuration is needed
    string interpolatedTemplate;

    if (dto.EnableEntityConfiguration)
    {
      var entityConfigurationNamespace = NamespaceUtils
        .ComposeEntityConfigurationNameSpace(dto.ProjectName, dto.EntityPluralName);

      interpolatedTemplate = InterpolateEntityTemplateWithEntityConfigurationFile(
        template: entityTemplate,
        entitySingularName: dto.EntitySingularName,
        entityNamespace: entityNamespace,
        entityConfigurationNamespace: entityConfigurationNamespace
      );
    }
    else
    {
      interpolatedTemplate = InterpolateEntityTemplate(entityTemplate, dto.EntitySingularName, entityNamespace);
    }

    // Write template to file
    TemplateFileRepository
      .WriteTemplate(interpolatedTemplate, entityDirectoryPath, $"{dto.EntitySingularName}.cs");
  }

  private static string InterpolateEntityTemplate(string template, string entitySingularName, string entityNamespace)
  {
    // We don't need imports in this case
    var entityFileSetup = $"namespace {entityNamespace};\n";

    var interpolatedFile = template.Replace(EntityFileSetupNeedle, entityFileSetup);

    // Add Entity Name
    return interpolatedFile.Replace(EntityNameNeedle, entitySingularName);
  }

  private static string InterpolateEntityTemplateWithEntityConfigurationFile(string template,
    string entitySingularName, string entityNamespace, string entityConfigurationNamespace)
  {
    var entityFileSetup = "using Microsoft.EntityFrameworkCore;\n";
    entityFileSetup += $"using {entityConfigurationNamespace}; \n";
    entityFileSetup += "\n";
    entityFileSetup += $"namespace {entityNamespace};\n";
    entityFileSetup += "\n";

    entityFileSetup += $"[EntityTypeConfiguration(typeof({entitySingularName}EntityConfiguration))]";

    var interpolatedFile = template.Replace(EntityFileSetupNeedle, entityFileSetup);

    return interpolatedFile.Replace(EntityNameNeedle, entitySingularName);
  }

  private static string CreateEntitiesFolder(string modulePath)
  {
    var entityDirectoryPath = Path.Combine(modulePath, "Entities");
    Directory.CreateDirectory(entityDirectoryPath);

    return entityDirectoryPath;
  }

  private static string GetEntityTemplate()
  {
    return TemplateFileRepository.GetTemplateFileFromAssembly(EntityTemplateFileName);
  }
}