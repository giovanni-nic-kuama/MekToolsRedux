using MekToolsReduxComponents.Modules.Dashboard.Models;

namespace MekToolsReduxComponents.Modules.Dashboard.Pages;

public partial class DashboardPage
{
  private ProjectSettings ProjectSettings { get; set; } = new();


  private void OnProjectSettingsChange(ProjectSettings value)
  {
    Console.WriteLine(value);
    ProjectSettings = value;
  }
}