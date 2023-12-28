namespace MekToolsReduxCore.Modules.ModulePreviews.Models;

public class ModuleDirectoryPreviewModel
{
  public string Name { get; set; } = null!;

  public List<ModuleFilePreviewModel> Files { get; set; } = null!;
}