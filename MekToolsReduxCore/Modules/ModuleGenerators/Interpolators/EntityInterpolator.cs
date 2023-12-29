using MekToolsReduxCore.Modules.ModuleGenerators.Models;

namespace MekToolsReduxCore.Modules.ModuleGenerators.Interpolators;

public static class EntityInterpolator
{
  private const string NamespaceNeedle = "---namespace-needle---";
  private const string EntityNameNeedle = "---entity-name-needle---";

  public static string InterpolateFile(string file, EntityCreateModel model)
  {
    var fileWithNamespace = file.Replace(NamespaceNeedle, model.Namespace);
    return fileWithNamespace.Replace(EntityNameNeedle, model.EntityName);
  }
}