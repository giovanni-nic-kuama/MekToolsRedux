using MekToolsReduxCore.Modules.ProjectFolders.Models;
using MekToolsReduxCore.Modules.ProjectInfos.Models;
using MekToolsReduxCore.Modules.Projects.Repositories;

namespace MekToolsReduxCore.Modules.ProjectInfos.Services;

public static class ProjectInfoService
{
  public static ProjectInfo ScanFolderForProject(string path)
  {
    var modulesPath = ProjectRepository.GetModulesPath(path); 
    var projectName = ProjectRepository.GetProjectName(path); 

    return new ProjectInfo
    {
      ProjectPath = path,
      ModulesPath = modulesPath,
      ProjectName = projectName,
    };
  }
  
  public static List<ProjectFolder> GetProjectModules(string modulesPath)
  {
    var projectModules = ProjectRepository.GetProjectModules(modulesPath);
    
    return projectModules.Select(e => new ProjectFolder
    {
      Name = e,
      IsGenerated = false
    }).ToList();
  }
}