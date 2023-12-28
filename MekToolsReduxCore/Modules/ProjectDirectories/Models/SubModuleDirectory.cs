namespace MekToolsReduxCore.Modules.ProjectDirectories.Models;

public class SubModuleDirectory
{
  public string Name { get; set; } = null!;

  public List<ModuleFile> ModuleFiles { get; set; } = null!;
}