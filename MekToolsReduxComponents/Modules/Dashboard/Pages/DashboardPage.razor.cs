using MekToolsReduxComponents.Modules.Dashboard.Models;

namespace MekToolsReduxComponents.Modules.Dashboard.Pages;

public partial class DashboardPage
{
  private ProjectSettings ProjectSettings { get; set; } = new();

  private ProjectInfos? ProjectInfos { get; set; }

  private List<ProjectFolder> ProjectFolders { get; set; } = new();

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

  // TODO: delete
  private void InitializeProjectFolders()
  {
    ProjectFolders = new List<ProjectFolder>()
    {
      new()
      {
        Name = "Accounts",
        IsGenerated = false
      },
      new()
      {
        Name = "BioEthicalIssue",
        IsGenerated = false
      },
      new()
      {
        Name = "BioMedicalIssues",
        IsGenerated = false
      },
      new()
      {
        Name = "Patients",
        IsGenerated = false
      },
      new()
      {
        Name = "Users",
        IsGenerated = false
      },
      new()
      {
        Name = "Zebras",
        IsGenerated = true
      }
    }.OrderBy(e => e.Name).ToList();
  }

  private void OnValidProjectPath()
  {
    InitializeProjectInfos();
    InitializeProjectFolders();
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