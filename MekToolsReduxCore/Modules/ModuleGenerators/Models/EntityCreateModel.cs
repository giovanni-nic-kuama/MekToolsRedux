namespace MekToolsReduxCore.Modules.ModuleGenerators.Models;

public class EntityCreateModel
{
  public string EntityName { get; init; } = null!;

  public string Namespace { get; init; } = null!;

  public string FileName => $"{EntityName}.cs";
}