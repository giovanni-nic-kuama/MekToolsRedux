using System.Reflection;
using MekToolsReduxComponents.Modules.Index.Pages;
using MekToolsReduxComponents.Modules.Main;

namespace MekToolsReduxComponents.Modules;

public static class ExportedMekToolsComponentsAssemblies
{
  // Index Page
  private static readonly Assembly IndexPageAssembly = typeof(IndexPage).Assembly;

  // Dummy Page
  private static readonly Assembly DummyPageAssembly = typeof(MainPage).Assembly;


  public static Assembly[] All = new[] { IndexPageAssembly, DummyPageAssembly };
}