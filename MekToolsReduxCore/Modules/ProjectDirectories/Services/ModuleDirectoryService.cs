using MekToolsReduxCore.Modules.ProjectDirectories.Models;

namespace MekToolsReduxCore.Modules.ProjectDirectories.Services;

public static class ModuleDirectoryService
{
  public static ModuleDirectory GetPreview(string singularName, string pluralName)
  {
    var dtoTypes = new[] { "ReadDto", "CreateDto", "UpdateDto" };
    
    var entityFile = new ModuleFile
    {
      Name = $"{singularName}.cs"
    };
    
    var mappingsFile = new ModuleFile
    {
      Name = $"{singularName}Mappings.cs"
    };
    
    var serviceInterfaceFile = new ModuleFile
    {
      Name = $"I{singularName}Service.cs"
    };
    
    var repositoryFile = new ModuleFile
    {
      Name = $"I{singularName}Repository.cs"
    };
    
    var serviceImplFile = new ModuleFile
    {
      Name = $"{singularName}Service.cs"
    };
    
    var controllerFile = new ModuleFile
    {
      Name = $"{pluralName}Controller.cs"
    };
    
    var controllersFolder = new SubModuleDirectory
    {
      Name = "Controllers",
      ModuleFiles = new List<ModuleFile>()
      {
        controllerFile
      }
    };

    var dtosFile = dtoTypes.Select(it => new ModuleFile { Name = $"{singularName}{it}.cs" }).ToList();
    
    var dtosFolder = new SubModuleDirectory
    {
      Name = "Dtos",
      ModuleFiles = dtosFile
    };

    var entitiesFolder = new SubModuleDirectory
    {
      Name = "Entities",
      ModuleFiles = new List<ModuleFile>
      {
        entityFile
      }
    };

    var mappingFolders = new SubModuleDirectory
    {
      Name = "Mappings",
      ModuleFiles = new List<ModuleFile>
      {
        mappingsFile
      }
    };
    
    var repositoriesFolders = new SubModuleDirectory
    {
      Name = "Repositories",
      ModuleFiles = new List<ModuleFile>
      {
        repositoryFile
      }
    };
    
    var servicesFolders = new SubModuleDirectory
    {
      Name = "Services",
      ModuleFiles = new List<ModuleFile>
      {
        serviceInterfaceFile,
        serviceImplFile
      }
    };
    
    var validatorsFile = dtoTypes.Where(it => it != "ReadDto").Select(it => new ModuleFile { Name = $"{singularName}{it}Validator.cs" }).ToList();
    var validatorsFolders = new SubModuleDirectory
    {
      Name = "Validators",
      ModuleFiles = validatorsFile
    };

    var directories = new List<SubModuleDirectory>
    {
      entitiesFolder,
      mappingFolders,
      servicesFolders,
      controllersFolder,
      dtosFolder,
      repositoriesFolders,
      validatorsFolders
    }.OrderBy(e => e.Name).ToList();

    return new ModuleDirectory
    {
      Name = pluralName,
      SubModuleDirectories = directories
    };
  }
}