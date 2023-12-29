namespace MekToolsReduxCore.Modules.ModuleGenerators.Models;

public class ControllerCreateModel
{
  public string ControllerName { get; set; } = null!;

  public string Namespace { get; set; } = null!;

  public string FileName => $"{ControllerName}.cs";
}