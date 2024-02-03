using MekToolsReduxCore.Modules.ModuleGenerators.Dtos;
using MekToolsReduxCore.Modules.ModuleGenerators.Utils;

namespace MekToolsReduxCore.Modules.ModuleGenerators.Repositories;

public static class RepositoryFileRepository
{
  public static void CreateRepositoriesFolderAndGenerateTemplate(string modulePath, ModuleCreateDto dto)
  {
    var repositoriesDirectoryPath = CreateRepositoriesFolder(modulePath);
    var repositoryNamespace = NamespaceUtils.ComposeRepositoryNameSpace(dto.ProjectName, dto.EntityPluralName);
    
    GenerateRepository(
      className: $"{dto.EntitySingularName}Repository",
      repositoriesDirectoryPath: repositoriesDirectoryPath,
      repositoriesNamespace: repositoryNamespace);
  }
  
  private static void GenerateRepository(string className, string repositoriesDirectoryPath, string repositoriesNamespace)
  {

    var interpolatedTemplate = $"namespace {repositoriesNamespace};\n";
    interpolatedTemplate += "\n";
    interpolatedTemplate += $"public static class {className}\n";
    interpolatedTemplate += "{";
    interpolatedTemplate += "\n    \n";
    interpolatedTemplate += "}";
    interpolatedTemplate += "\n";

    TemplateFileRepository.WriteTemplate(interpolatedTemplate, repositoriesDirectoryPath, $"{className}.cs");
  }
  
  private static string CreateRepositoriesFolder(string modulePath)
  {
    var entityDirectoryPath = Path.Combine(modulePath, "Repositories");
    Directory.CreateDirectory(entityDirectoryPath);

    return entityDirectoryPath;
  }
}