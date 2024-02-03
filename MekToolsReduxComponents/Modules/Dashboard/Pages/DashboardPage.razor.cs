using MekToolsReduxComponents.Modules.Dashboard.Forms;
using MekToolsReduxComponents.Modules.Dashboard.Mappings;
using MekToolsReduxComponents.Modules.Dashboard.Models;
using MekToolsReduxComponents.Modules.Dashboard.ViewUtils;
using MekToolsReduxCore.Modules.ModuleGenerators.Services;
using MekToolsReduxCore.Modules.ModulePreviews.Models;
using MekToolsReduxCore.Modules.ModulePreviews.Services;
using MekToolsReduxCore.Modules.ProjectFolders.Models;
using MekToolsReduxCore.Modules.ProjectInfos.Models;
using MekToolsReduxCore.Modules.ProjectInfos.Services;

namespace MekToolsReduxComponents.Modules.Dashboard.Pages;

public partial class DashboardPage
{
  private ProjectSettings ProjectSettings { get; set; } = new();

  private ProjectInfo? ProjectInfos { get; set; }

  private List<ProjectFolder> ProjectFolders { get; set; } = new();
  
  private ModulePreviewModel? ModulePreviewModel { get; set; }
  
  private void OnValidProjectPath(ProjectPathFormModel model)
  {
    InitializeProjectInfoAndModules(model);
  }
  
  private void InitializeProjectInfoAndModules(ProjectPathFormModel model)
  {
    ProjectInfos = ProjectInfoService.ScanFolderForProject(model.ProjectPath);

    if (ProjectInfos.ModulesPath != null)
    {
      ProjectFolders = ProjectInfoService.GetProjectModules(ProjectInfos.ModulesPath);
    }
  }

  private void OnProjectSettingsChange(ProjectSettings projectSettings)
  {
    ModulePreviewModel = ModulePreviewService
      .GenerateModulePreview(dto: ProjectMappings.MapToDto(projectSettings));

    ProjectFolders = DashboardPageViewUtils
      .UpdateProjectFolderListWithGeneratedModule(ProjectFolders, ModulePreviewModel.ModuleName);
    
    ProjectSettings = projectSettings;
  }

  private void OnClickGenerateModule()
  {
    if (ProjectInfos?.ModulesPath != null)
    {
      var moduleCreateDto = ProjectMappings
        .MapToModuleCreateDto(ProjectSettings, ProjectInfos.ModulesPath);
      
      ModuleGeneratorService.GenerateModule(moduleCreateDto);
    }
  }

  private void UnloadProject()
  {
    ProjectInfos = null;
    StateHasChanged();
  }
}