namespace MekToolsReduxComponents.Modules.Dashboard.Models;

public record ProjectInfos
{
  public string ProjectPath { get; set; } = null!;

  public string? ModulesPath { get; set; }

  public string ProjectName { get; set; } = null!;

  public string CsProjName => $"{ProjectName}.csproj";
}