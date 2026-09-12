namespace SolutionWalker.Domain.ServiceInterfaces;

public interface IDataImportService
{
    void ImportVisualStudioSolutions(string sqliteFilePath, string solutionsPath);
}
