namespace MekToolsReduxCore.Modules.ProjectInfos.Models;

public record ProjectInfo
{
  public string ProjectPath { get; set; } = null!;

  public string? ModulesPath { get; set; }

  public string? ProjectName { get; set; }

  public string CsProjName => $"{ProjectName}.csproj";
}