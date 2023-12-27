using System.ComponentModel.DataAnnotations;

namespace MekToolsReduxComponents.Modules.Index.Models;

[Serializable]
public class ModuleCreateModel
{
  [Required(ErrorMessage = "Entity singular name is required")]
  [StringLength(15, ErrorMessage = "Entity singular name must be shorter than 15 characters")]
  public string EntitySingularName { get; set; } = "";

  [Required(ErrorMessage = "Entity plural name is required")]
  [StringLength(15, ErrorMessage = "Entity singular name must be shorter than 15 characters")]
  public string EntityPluralName { get; set; } = "";

  [Required(ErrorMessage = "Destination path is required")]
  [StringLength(200, ErrorMessage = "Destination path must be shorter than 200 characters")]
  public string DestinationPath { get; set; } = "";
}