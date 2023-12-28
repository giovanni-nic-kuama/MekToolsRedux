namespace MekToolsReduxCore.Modules.ProjectDirectories.Models;

public class ModuleDirectory
{
  public string Name { get; set; } = null!;

  public List<SubModuleDirectory> SubModuleDirectories { get; set; } = null!;
}