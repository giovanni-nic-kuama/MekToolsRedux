using MekToolsReduxCore.Modules.ModuleGenerators.Models;

namespace MekToolsReduxCore.Modules.ModuleGenerators.Interpolators;

public static class ControllerInterpolator
{
  private const string NamespaceNeedle = "---namespace-needle---";
  private const string ControllerNameNeedle = "---controller-name-needle---";

  public static string InterpolateFile(string file, ControllerCreateModel model)
  {
    var fileWithNamespace = file.Replace(NamespaceNeedle, model.Namespace);
    return fileWithNamespace.Replace(ControllerNameNeedle, model.ControllerName);
  }
}