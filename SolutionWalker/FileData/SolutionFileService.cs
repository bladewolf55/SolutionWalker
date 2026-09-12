using SolutionWalker.Domain.Models;
using SolutionWalker.Domain.ServiceInterfaces;

namespace SolutionWalker.FileData;

public class SolutionFileService : ISolutionFileService
{
    public SolutionFile ParseVisualStudioSolution(string filePath)
    {
        var helper = new VisualStudioSolutionHelpers();
        var solutionFile = helper.Parse(filePath);
        return solutionFile;
    }
}
