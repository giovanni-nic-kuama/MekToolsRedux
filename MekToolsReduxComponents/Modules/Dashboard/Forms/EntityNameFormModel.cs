using System.ComponentModel.DataAnnotations;

namespace MekToolsReduxComponents.Modules.Dashboard.Forms;

[Serializable]
public class EntityNameFormModel
{
  [Required(ErrorMessage = "Entity singular name is required")]
  [RegularExpression(pattern:"/^[A-Z][a-z0-9_-]{3,19}$/", ErrorMessage = "Entity singular name must start with uppercase character")]
  public string EntitySingularName { get; set; } = "Temperature";
  
  [Required(ErrorMessage = "Entity plural name is required")]
  [RegularExpression(pattern:"/[a-zA-Z]/", ErrorMessage = "Entity plural name must start with uppercase character")]
  public string EntityPluralName { get; set; } = "Temperatures";
}