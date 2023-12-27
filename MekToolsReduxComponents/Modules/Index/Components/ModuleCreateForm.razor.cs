using MekToolsReduxComponents.Modules.Index.Models;
using Microsoft.AspNetCore.Components;

namespace MekToolsReduxComponents.Modules.Index.Components;

public partial class ModuleCreateForm
{
  [Parameter] public EventCallback<ModuleCreateModel> OnValidFormSubmit { get; set; }

  // TODO: remove initialization
  private ModuleCreateModel ModuleCreateModel { get; set; } = new()
  {
    DestinationPath = "C:\\Lavoro",
    EntitySingularName = "Temperature",
    EntityPluralName = "Temperatures"
  };

  private bool DirectoryHasAccessProblems { get; set; }

  private void OnValidSubmit()
  {
    var isPathValid = ValidatePath(ModuleCreateModel.DestinationPath);

    if (isPathValid)
    {
      OnValidFormSubmit.InvokeAsync(ModuleCreateModel);
      return;
    }

    DirectoryHasAccessProblems = true;
  }

  private void OnFormInValid()
  {
    // no-op 
  }

  // TODO: move into core
  private bool ValidatePath(string path)
  {
    var directoryExists = Directory.Exists(path);
    Console.WriteLine("Directory Exists: " + directoryExists);

    if (!directoryExists) return directoryExists;
    var hasWritePermission = HasWritePermission(path);
    Console.WriteLine("HasWritePermission: " + hasWritePermission);
    
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
  private void WriteFile()
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