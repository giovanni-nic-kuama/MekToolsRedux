using MekToolsReduxCore.Modules.ModuleGenerators.Dtos;
using MekToolsReduxCore.Modules.ModuleGenerators.Models;

namespace MekToolsReduxCore.Modules.ModuleGenerators.Mappings;

public static class ModuleMappings
{
  public static ModuleCreateModel Map(ModuleCreateDto dto)
  {
    const string tempNamespace = "com.kuama.todo";

    var entityCreateModel = new EntityCreateModel()
    {
      EntityName = dto.EntitySingularName,
      Namespace = tempNamespace
    };

    var controllerCreateModel = new ControllerCreateModel()
    {
      ControllerName = $"{dto.EntityPluralName}Controller",
      Namespace = tempNamespace
    };

    return new ModuleCreateModel
    {
      ModuleName = dto.EntityPluralName,
      EntityCreateModel = entityCreateModel,
      ControllerCreateModel = controllerCreateModel
    };
  }
}