using System.ComponentModel.DataAnnotations;

namespace MekToolsReduxComponents.Modules.Dashboard.Forms;

[Serializable]
public class EntityNameFormModel
{
  [Required(ErrorMessage = "Entity singular name is required")]
  public string EntitySingularName { get; set; } = "Temperature";
  
  [Required(ErrorMessage = "Entity plural name is required")]
  public string EntityPluralName { get; set; } = "Temperatures";
}