namespace MekToolsReduxCore.Modules.Projects.Repositories;

public static class ProjectRepository
{
  public static string? GetModulesPath(string path)
  {
    var folderFiles = Directory.EnumerateDirectories(path);
    
    var modulesFolderExists = folderFiles
      .Any(e => e == Path.Combine(path, "Modules"));

    return modulesFolderExists ? Path.Combine(path, "Modules") : null;
  }

  public static string? GetProjectName(string path)
  {
    var folderFiles = Directory.EnumerateFiles(path);

    var csProjAbsolutePath = folderFiles
      .FirstOrDefault(e => e.Contains(".csproj"));
    
    var file = csProjAbsolutePath?.Split(Path.DirectorySeparatorChar).Last();
    
    return file?.Replace(".csproj", "");
  }

  public static List<string> GetProjectModules(string modulesPath)
  {
    return Directory
      .EnumerateDirectories(modulesPath)
      .Select(e => e.Replace(modulesPath + Path.DirectorySeparatorChar, ""))
      .ToList();
  }
}