using System.Reflection;
using MekToolsReduxComponents.Modules.Dashboard.Pages;

namespace MekToolsReduxComponents.Modules;

public static class ExportedMekToolsComponentsAssemblies
{
  // Dashboard Page
  private static readonly Assembly DashboardAssembly = typeof(DashboardPage).Assembly;

  public static readonly Assembly[] All = { DashboardAssembly };
}