using MekToolsReduxComponents.Modules.Index.Models;
using Microsoft.AspNetCore.Components;

namespace MekToolsReduxComponents.Modules.Index.Components;

public partial class ModuleCreateForm
{
  [Parameter] public EventCallback<ModuleCreateModel> OnValidFormSubmit { get; set; }

  private ModuleCreateModel ModuleCreateModel { get; set; } = new();

  private void OnValidSubmit()
  {
    Console.WriteLine("Valid submit");
    // TODO: validate path exists and is writeable
    OnValidFormSubmit.InvokeAsync(ModuleCreateModel);
  }

  private void OnFormInValid()
  {
    // no-op 
  }

  // TODO: working
  private void WriteFile()
  {
    string[] lines = { "First line", "Second line", "Third line" };

    // Set a variable to the Documents path.
    string docPath =
      Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    // Write the string array to a new file named "WriteLines.txt".
    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")))
    {
      foreach (string line in lines)
        outputFile.WriteLine(line);
    }

    Directory.CreateDirectory(Path.Combine("C:\\Users\\Noitu\\Desktop", "MODULES"));
  }
}