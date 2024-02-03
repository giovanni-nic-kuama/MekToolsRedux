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
}