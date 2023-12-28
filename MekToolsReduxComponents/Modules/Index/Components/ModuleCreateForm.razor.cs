using MekToolsReduxComponents.Modules.Index.Models;
using MekToolsReduxCore.Modules.ModuleGenerators.Services;
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
    var isPathValid = ModuleGeneratorService.ValidatePath(ModuleCreateModel.DestinationPath);

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


  private static void OnSubmitButtonClick()
  {
    //no-op
  }
}