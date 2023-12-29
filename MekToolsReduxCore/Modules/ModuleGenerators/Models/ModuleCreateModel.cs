namespace MekToolsReduxCore.Modules.ModuleGenerators.Models;

public class ModuleCreateModel
{
  public string ModuleName { get; set; } = null!;

  public EntityCreateModel EntityCreateModel { get; set; } = null!;

  public ControllerCreateModel ControllerCreateModel { get; set; } = null!;
}