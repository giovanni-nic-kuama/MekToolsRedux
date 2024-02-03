using MekToolsReduxCore.Modules.ModuleGenerators.Dtos;
using MekToolsReduxCore.Modules.ModuleGenerators.Utils;

namespace MekToolsReduxCore.Modules.ModuleGenerators.Repositories;

public static class DtosFileRepository
{
  private const string GenericClassFileName = "GenericClass.txt";
  private const string NamespaceNeedle = "---namespace-needle---";
  private const string DtoNameNeedle = "---generic-class-name-needle---";
  
  public static void CreateDtosFolderAndGenerateTemplates(string modulePath, ModuleCreateDto dto)
  {
    var dtosDirectoryPath = CreateDtosFolder(modulePath);
    
    // Read stored template to bytes
    var genericClassTemplate = GetGenericClassTemplate();
    var dtosNamespace = NamespaceUtils.ComposeDtosNameSpace(dto.ProjectName, dto.EntityPluralName);

    if (dto.EnableUpsertDto)
    {
      GenerateDto($"{dto.EntitySingularName}ReadDto", dtosDirectoryPath, genericClassTemplate, dtosNamespace);
      GenerateDto($"{dto.EntitySingularName}UpsertDto", dtosDirectoryPath, genericClassTemplate, dtosNamespace);
      return;
    }
    
    GenerateDto($"{dto.EntitySingularName}ReadDto", dtosDirectoryPath, genericClassTemplate, dtosNamespace);
    GenerateDto($"{dto.EntitySingularName}CreateDto", dtosDirectoryPath, genericClassTemplate, dtosNamespace);
    GenerateDto($"{dto.EntitySingularName}UpdateDto", dtosDirectoryPath, genericClassTemplate, dtosNamespace);
  }

  private static void GenerateDto(string className, string dtosDirectoryPath, string genericClassTemplate, string dtosNamespace)
  {
    var interpolatedTemplate = genericClassTemplate;
    interpolatedTemplate = interpolatedTemplate.Replace(NamespaceNeedle, $"namespace {dtosNamespace};");
    interpolatedTemplate = interpolatedTemplate.Replace(DtoNameNeedle, className);
    
    TemplateFileRepository.WriteTemplate(interpolatedTemplate, dtosDirectoryPath, $"{className}.cs");
  }

  private static string CreateDtosFolder(string modulePath)
  {
    var entityDirectoryPath = Path.Combine(modulePath, "Dtos");
    Directory.CreateDirectory(entityDirectoryPath);

    return entityDirectoryPath;
  }
  
  private static string GetGenericClassTemplate()
  {
    return TemplateFileRepository.GetTemplateFileFromAssembly(GenericClassFileName);
  }
}