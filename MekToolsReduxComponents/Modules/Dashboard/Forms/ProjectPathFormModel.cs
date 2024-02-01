using System.ComponentModel.DataAnnotations;


namespace MekToolsReduxComponents.Modules.Dashboard.Forms;

[Serializable]
public class ProjectPathFormModel
{
  [Required(ErrorMessage = "Destination path is required")]
  public string ProjectPath { get; set; } = "C:\\Lavoro\\ethical-unipd\\web-api";
}