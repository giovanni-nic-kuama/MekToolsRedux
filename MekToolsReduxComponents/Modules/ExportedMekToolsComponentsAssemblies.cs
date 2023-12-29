using System.Reflection;
using MekToolsReduxComponents.Modules.Main.Pages;

namespace MekToolsReduxComponents.Modules;

public static class ExportedMekToolsComponentsAssemblies
{
  // Dashboard Page
  private static readonly Assembly DashboardAssembly = typeof(MainPage).Assembly;

  public static Assembly[] All = new[] { DashboardAssembly };
}