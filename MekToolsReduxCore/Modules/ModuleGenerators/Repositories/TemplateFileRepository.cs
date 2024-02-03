using System.Reflection;
using System.Text;
using MekToolsReduxCore.Modules.ModuleGenerators.Exceptions;

namespace MekToolsReduxCore.Modules.ModuleGenerators.Repositories;

public static class TemplateFileRepository
{
  private const string ProjectNamespace = "MekToolsReduxCore.Resources";

  public static void WriteTemplate(string interpolatedTemplate, string path, string fileName)
  {
    var bytes = Encoding.ASCII.GetBytes(interpolatedTemplate);
    var currentFilePath = Path.Combine(path, fileName);

    // Write File
    File.WriteAllBytes(currentFilePath, bytes);
  }

  public static string GetTemplateFileFromAssembly(string fileName)
  {
    var assembly = Assembly.GetExecutingAssembly();
    var resourceName = ComposeFileNameFromAssembly(fileName);
    using var stream = assembly.GetManifestResourceStream(resourceName);

    if (stream == null)
    {
      throw new TemplateNotFoundException();
    }

    using var reader = new StreamReader(stream);
    return reader.ReadToEnd();
  }

  private static string ComposeFileNameFromAssembly(string filename)
  {
    return $"{ProjectNamespace}.{filename}";
  }
}