using SolutionWalker.Domain.Models;

namespace SolutionWalker.Domain.ServiceInterfaces;

public interface ISolutionFileService
{
    SolutionFile ParseVisualStudioSolution(string filePath);
}
