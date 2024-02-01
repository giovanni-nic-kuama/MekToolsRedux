using MekToolsReduxComponents.Modules.Dashboard.Forms;
using MekToolsReduxComponents.Modules.Dashboard.Models;
using MekToolsReduxCore.Modules.ProjectFolders.Models;
using MekToolsReduxCore.Modules.ProjectInfos.Models;
using MekToolsReduxCore.Modules.ProjectInfos.Services;

namespace MekToolsReduxComponents.Modules.Dashboard.Pages;

public partial class DashboardPage
{
  private ProjectSettings ProjectSettings { get; set; } = new();

  private ProjectInfo? ProjectInfos { get; set; }

  private List<ProjectFolder> ProjectFolders { get; set; } = new();
  
  private void OnValidProjectPath(ProjectPathFormModel model)
  {
    InitializeProjectInfoAndModules(model);
  }
  
  private void InitializeProjectInfoAndModules(ProjectPathFormModel model)
  {
    ProjectInfos = ProjectInfoService.ScanFolderForProject(model.ProjectPath);

    if (ProjectInfos.ModulesPath != null)
    {
      ProjectFolders = ProjectInfoService.GetProjectModules(ProjectInfos.ModulesPath);
    }
  }

  private void OnProjectSettingsChange(ProjectSettings value)
  {
    Console.WriteLine(value);
    ProjectSettings = value;
  }

  private void UnloadProject()
  {
    ProjectInfos = null;
    StateHasChanged();
  }
}