using MekToolsReduxCore.Modules.ModuleGenerators.Dtos;
using MekToolsReduxCore.Modules.ModuleGenerators.Utils;

namespace MekToolsReduxCore.Modules.ModuleGenerators.Repositories;

public class ValidatorsFileRepository
{
  private const string ValidatorTemplateFilename = "Validator.txt";
  private const string ImportsAndNamespaceNeedle = "---imports-and-namespace-needle---";
  private const string DtoNameNeedle = "---dto-name---";

  public static void CreateValidatorsFolderAndGenerateClasses(string modulePath, ModuleCreateDto dto)
  {
    var validatorsDirectoryPath = CreateValidatorsFolder(modulePath);

    var dtosNamespace = NamespaceUtils.ComposeDtosNameSpace(dto.ProjectName, dto.EntityPluralName);
    var validatorsNamespace = NamespaceUtils.ComposeValidatorsNameSpace(dto.ProjectName, dto.EntityPluralName);
    var validatorTemplate = GetMappingsTemplate();

    if (dto.EnableUpsertDto)
    {
      GenerateTemplate(
        template: validatorTemplate,
        dtosNamespace: dtosNamespace,
        validatorsNamespace: validatorsNamespace,
        dtoName: $"{dto.EntitySingularName}UpsertDto",
        validatorsDirectoryPath: validatorsDirectoryPath
      );
      return;
    }
    
    GenerateTemplate(
      template: validatorTemplate,
      dtosNamespace: dtosNamespace,
      validatorsNamespace: validatorsNamespace,
      dtoName: $"{dto.EntitySingularName}CreateDto",
      validatorsDirectoryPath: validatorsDirectoryPath
    );
    
    GenerateTemplate(
      template: validatorTemplate,
      dtosNamespace: dtosNamespace,
      validatorsNamespace: validatorsNamespace,
      dtoName: $"{dto.EntitySingularName}UpdateDto",
      validatorsDirectoryPath: validatorsDirectoryPath
    );
  }

  private static void GenerateTemplate(string template, string dtosNamespace,
    string validatorsNamespace, string dtoName, string validatorsDirectoryPath)
  {
    var interpolatedTemplate = template;

    var importAndNameSpace = $"using {dtosNamespace};\n\n";
    importAndNameSpace += $"namespace {validatorsNamespace};";

    interpolatedTemplate = interpolatedTemplate.Replace(ImportsAndNamespaceNeedle, importAndNameSpace);
    interpolatedTemplate = interpolatedTemplate.Replace(DtoNameNeedle, dtoName);

    TemplateFileRepository.WriteTemplate(interpolatedTemplate, validatorsDirectoryPath, $"{dtoName}Validator.cs");
  }

  private static string CreateValidatorsFolder(string modulePath)
  {
    var entityDirectoryPath = Path.Combine(modulePath, "Validators");
    Directory.CreateDirectory(entityDirectoryPath);

    return entityDirectoryPath;
  }

  private static string GetMappingsTemplate()
  {
    return TemplateFileRepository.GetTemplateFileFromAssembly(ValidatorTemplateFilename);
  }
}