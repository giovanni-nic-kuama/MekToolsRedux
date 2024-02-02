using MekToolsReduxCore.Modules.ProjectFolders.Models;

namespace MekToolsReduxComponents.Modules.Dashboard.ViewUtils;

public static class DashboardPageViewUtils
{
  public static List<ProjectFolder> UpdateProjectFolderListWithGeneratedModule(List<ProjectFolder> projectFolders,
    string generatedModuleName)
  {
    var nonGeneratedFolders = projectFolders.Where(e => !e.IsGenerated).ToList();
    nonGeneratedFolders.Add(new ProjectFolder { IsGenerated = true, Name = generatedModuleName });

    return nonGeneratedFolders.OrderBy(e => e.Name).ToList();
  }
}