using MekToolsReduxComponents.Modules.Dashboard.Models;

namespace MekToolsReduxComponents.Modules.Dashboard.Pages;

public partial class DashboardPage
{
  private ProjectSettings ProjectSettings { get; set; } = new();

  private ProjectInfos? ProjectInfos { get; set; }

  protected override void OnInitialized()
  {
    InitializeProjectInfos();

    base.OnInitialized();
  }

  // TODO: delete
  private void InitializeProjectInfos()
  {
    ProjectInfos = new ProjectInfos
    {
      ModulesPath = "C:\\Lavoro\\MekToolsRedux\\MekToolsReduxCore\\Modules",
      ProjectPath = "C:\\Lavoro\\MekToolsRedux\\MekToolsReduxCore",
      ProjectName = "MekToolsReduxCore"
    };
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