using MekToolsReduxCore.Modules.ModuleGenerators.Dtos;
using MekToolsReduxCore.Modules.ModuleGenerators.Utils;

namespace MekToolsReduxCore.Modules.ModuleGenerators.Repositories;

public static class MappingsFileRepository
{
  private const string MappingsTemplateFilename = "Mappings.txt";
  private const string MappingsForUpsertTemplateFilename = "MappingsForUpsert.txt";
  private const string ImportsAndNamespaceNeedle = "---imports-and-namespace-needle---";
  private const string EntityNameNeedle = "---entity-name-needle---";
  private const string ReadDtoNeedle = "---read-dto---";
  private const string CreateDtoNeedle = "---create-dto---";
  private const string UpdateDtoNeedle = "---update-dto---";
  private const string UpsertDtoNeedle = "---upsert-dto---";
  
  public static void CreateMappingsFolderAndGenerateTemplate(string modulePath, ModuleCreateDto dto)
  {
    var mappingsDirectoryPath = CreateMappingsFolder(modulePath);
    
    var dtosNamespace = NamespaceUtils.ComposeDtosNameSpace(dto.ProjectName, dto.EntityPluralName);
    var entitiesNamespace = NamespaceUtils.ComposeEntityNameSpace(dto.ProjectName, dto.EntityPluralName);
    var mappingsNamespace = NamespaceUtils.ComposeMappingsNameSpace(dto.ProjectName, dto.EntityPluralName);

    if (!dto.EnableUpsertDto)
    {
      var mappingsTemplate = GetMappingsTemplate();
      
      GenerateStandardMappingsClass(
        dtosNamespace: dtosNamespace,
        entitiesNamespace: entitiesNamespace,
        mappingsNamespace: mappingsNamespace,
        className: $"{dto.EntitySingularName}Mappings",
        mappingsDirectoryPath: mappingsDirectoryPath,
        mappingsTemplate: mappingsTemplate,
        entitySingularName: dto.EntitySingularName);
      
      return;
    }
    
    var mappingsTemplateForUpsert = GetMappingsTemplateForUpsert();
    GenerateMappingsClassForUpsert(
      dtosNamespace: dtosNamespace,
      entitiesNamespace: entitiesNamespace,
      mappingsNamespace: mappingsNamespace,
      className: $"{dto.EntitySingularName}Mappings",
      mappingsDirectoryPath: mappingsDirectoryPath,
      mappingsTemplate: mappingsTemplateForUpsert,
      entitySingularName: dto.EntitySingularName);
  }

  public static void GenerateMappingsClassForUpsert(
    string dtosNamespace, string entitiesNamespace, 
    string mappingsNamespace, string className, string mappingsDirectoryPath, 
    string mappingsTemplate, string entitySingularName)
  {
    var interpolatedTemplate = mappingsTemplate;

    var mappingsImports = GenerateMappingsImports(dtosNamespace, entitiesNamespace, mappingsNamespace);

    interpolatedTemplate = interpolatedTemplate.Replace(ImportsAndNamespaceNeedle, mappingsImports);
    interpolatedTemplate = interpolatedTemplate.Replace(EntityNameNeedle, entitySingularName);
    interpolatedTemplate = interpolatedTemplate.Replace(ReadDtoNeedle, $"{entitySingularName}ReadDto");
    interpolatedTemplate = interpolatedTemplate.Replace(UpsertDtoNeedle, $"{entitySingularName}UpsertDto");
    
    TemplateFileRepository.WriteTemplate(interpolatedTemplate, mappingsDirectoryPath, $"{className}.cs");
  }

  private static void GenerateStandardMappingsClass(
    string dtosNamespace, string entitiesNamespace, 
    string mappingsNamespace, string className, string mappingsDirectoryPath, 
    string mappingsTemplate, string entitySingularName)
  {
    var interpolatedTemplate = mappingsTemplate;

    var mappingsImports = GenerateMappingsImports(dtosNamespace, entitiesNamespace, mappingsNamespace);

    interpolatedTemplate = interpolatedTemplate.Replace(ImportsAndNamespaceNeedle, mappingsImports);
    interpolatedTemplate = interpolatedTemplate.Replace(EntityNameNeedle, entitySingularName);
    interpolatedTemplate = interpolatedTemplate.Replace(ReadDtoNeedle, $"{entitySingularName}ReadDto");
    interpolatedTemplate = interpolatedTemplate.Replace(CreateDtoNeedle, $"{entitySingularName}CreateDto");
    interpolatedTemplate = interpolatedTemplate.Replace(UpdateDtoNeedle, $"{entitySingularName}UpdateDto");

    TemplateFileRepository.WriteTemplate(interpolatedTemplate, mappingsDirectoryPath, $"{className}.cs");
  }
  
  private static string GenerateMappingsImports(string dtosNamespace, string entitiesNamespace, string mappingsNamespace)
  {
    var mappingsImports = $"using {dtosNamespace};\n";
    mappingsImports += $"using {entitiesNamespace};\n";
    mappingsImports += "\n";
    mappingsImports += $"namespace {mappingsNamespace};";
    return mappingsImports;
  }
  
  private static string CreateMappingsFolder(string modulePath)
  {
    var entityDirectoryPath = Path.Combine(modulePath, "Mappings");
    Directory.CreateDirectory(entityDirectoryPath);

    return entityDirectoryPath;
  }
  
  private static string GetMappingsTemplate()
  {
    return TemplateFileRepository.GetTemplateFileFromAssembly(MappingsTemplateFilename);
  }
  
  private static string GetMappingsTemplateForUpsert()
  {
    return TemplateFileRepository.GetTemplateFileFromAssembly(MappingsForUpsertTemplateFilename);
  }
}