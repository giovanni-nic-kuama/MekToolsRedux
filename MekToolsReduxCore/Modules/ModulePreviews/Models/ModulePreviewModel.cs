namespace MekToolsReduxCore.Modules.ModulePreviews.Models;

public class ModulePreviewModel
{
  public string ModuleName { get; init; } = null!;

  public List<ModuleDirectoryPreviewModel> Directories { get; set; } = null!;
}