namespace MekToolsReduxCore.Modules.ModuleGenerators.Interpolators;

public class GenericClassInterpolator
{
  private const string NamespaceNeedle = "---namespace-needle---";
  private const string ClassNameNeedle = "---generic-class-name-needle---";

  public static string InterpolateFile(string file, string classNamespace, string className)
  {
    var fileWithNamespace = file.Replace(NamespaceNeedle, classNamespace);
    return fileWithNamespace.Replace(ClassNameNeedle, className);
  }
}