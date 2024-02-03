namespace MekToolsReduxCore.Modules.ModuleGenerators.Utils;

public static class NamespaceUtils
{
  public static string ComposeEntityNameSpace(string projectName, string entityPluralName)
  {
    return $"{projectName}.Modules.{entityPluralName}.Entities";
  }

  public static string ComposeEntityConfigurationNameSpace(string projectName, string entityPluralName)
  {
    return $"{projectName}.Modules.{entityPluralName}.EntitiesConfigurations";
  }
  
  public static string ComposeDtosNameSpace(string projectName, string entityPluralName)
  {
    return $"{projectName}.Modules.{entityPluralName}.Dtos";
  }

  public static string ComposeServiceNameSpace(string projectName, string entityPluralName)
  {
    return $"{projectName}.Modules.{entityPluralName}.Services";
  }

  public static string ComposeRepositoryNameSpace(string projectName, string entityPluralName)
  {
    return $"{projectName}.Modules.{entityPluralName}.Repositories";
  }

  public static string ComposeMappingsNameSpace(string projectName, string entityPluralName)
  {
    return $"{projectName}.Modules.{entityPluralName}.Mappings";
  }

  public static string ComposeValidatorsNameSpace(string projectName, string entityPluralName)
  {
    return $"{projectName}.Modules.{entityPluralName}.Validators";
  }
}