using MekToolsReduxCore.Modules.ModulePreviews.Models;

namespace MekToolsReduxCore.Modules.ModuleGenerators.Services;

public static class ModuleGeneratorService
{
  public static void GenerateModule(string filePath, ModulePreviewModel model)
  {
    // Assumption: directory does not exists


    // Step 1) Generate Module Name folder
    var modulePath = Path.Combine(filePath, model.ModuleName);
    Directory.CreateDirectory(modulePath);

    foreach (var moduleDirectory in model.Directories)
    {
      var directoryPath = Path.Combine(modulePath, moduleDirectory.Name);
      CreateDirectory(directoryPath);

      // Step 2) For each Folder, Create its files 
    }

    // Step 3) Interpolate C# files
    // First Possibility) +++timeconsuming Prepare a static class with all needed strings
    // Second Possibility) ---timeconsuming Have a "Template" File to read. Just need to replace a needle in the haystack 

    // Enhancements: Search main directory does not exists and bla blas
  }

  private static void CreateDirectory(string path)
  {
    var info = Directory.CreateDirectory(path);
    var ciao = "ciao";
  }

  public static bool ValidatePath(string path)
  {
    var directoryExists = Directory.Exists(path);

    if (!directoryExists) return directoryExists;
    var hasWritePermission = HasWritePermission(path);

    return directoryExists && hasWritePermission;
  }

  // TODO: move into core
  private static bool HasWritePermission(string filePath)
  {
    try
    {
      File.Create(Path.Combine(filePath, "temp.txt")).Close();
      File.Delete(Path.Combine(filePath, "temp.txt"));
    }
    catch (UnauthorizedAccessException)
    {
      return false;
    }

    return true;
  }

  // TODO: working
  private static void WriteFile()
  {
    string[] lines = { "First line", "Second line", "Third line" };

    // Set a variable to the Documents path.
    string docPath =
      Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    // Write the string array to a new file named "WriteLines.txt".
    using (var outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")))
    {
      foreach (var line in lines)
      {
        outputFile.WriteLine(line);
      }
    }

    Directory.CreateDirectory(Path.Combine("C:\\Users\\Noitu\\Desktop", "MODULES"));
  }
}