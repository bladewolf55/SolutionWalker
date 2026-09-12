namespace SolutionWalker.Domain.Models;

public record ProjectFile: ProjectProperties
{
   public List<ProjectFileReference> References { get; set; } = new();
}
