using MekToolsReduxCore.Modules.ModuleGenerators.Dtos;
using MekToolsReduxCore.Modules.ModuleGenerators.Repositories;

namespace MekToolsReduxCore.Modules.ModuleGenerators.Services;

public static class ModuleGeneratorService
{
  public static void GenerateModule(ModuleCreateDto dto)
  {
    // Step 1) Generate Module main folder
    var modulePath = Path.Combine(dto.ModulesPath, dto.EntityPluralName);

    // Step 2) Check if the module directory already exists. If true, delete it. Then recreate a new module directory
    CreateModuleFolderAndDeleteIfFolderAlreadyExists(modulePath: modulePath);

    // Step 3) Generate Entities Folder and Entity File
    EntityFileRepository.CreateEntitiesFolderAndGenerateTemplate(modulePath: modulePath, dto: dto);

    // Step 4) If enabled, generate EntityConfigurations Folder and EntityConfiguration File
    if (dto.EnableEntityConfiguration)
    {
      EntityConfigurationFileRepository.CreateEntitiesConfigurationFolderAndGenerateTemplate(
        modulePath: modulePath,
        dto: dto
      );
    }

    // Step 4) Generate Dtos folder and Dtos files based on configuration
    DtosFileRepository.CreateDtosFolderAndGenerateTemplates(modulePath: modulePath, dto: dto);

    // Step 5) Generate Services folder and IService an Service
    ServiceFileRepository.CreateServicesFolderAndGenerateTemplates(modulePath: modulePath, dto: dto);

    // Step 6) Generate Repositories folder and Repository Class, if enabled
    if (dto.EnableRepository)
    {
      RepositoryFileRepository.CreateRepositoriesFolderAndGenerateTemplate(modulePath: modulePath, dto: dto);
    }
    
    // Step 7) Generate Mappings folder and Mappings Class
    MappingsFileRepository.CreateMappingsFolderAndGenerateTemplate(modulePath: modulePath, dto: dto);

    if (dto.EnableValidators)
    {
      // Step 8) Generate Validators folder and Validator Classes
      ValidatorsFileRepository.CreateValidatorsFolderAndGenerateClasses(modulePath: modulePath, dto: dto); 
    }

    // Step 9) TODO: Controllers, they entities and dtos
  }

  private static void CreateModuleFolderAndDeleteIfFolderAlreadyExists(string modulePath)
  {
    if (Directory.Exists(modulePath))
    {
      Directory.Delete(modulePath, recursive: true);
    }

    Directory.CreateDirectory(modulePath);
  }
}