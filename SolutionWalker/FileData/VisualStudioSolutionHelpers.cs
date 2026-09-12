using SolutionWalker.Domain.Models;
using SolutionWalker.Domain.Utilities;
using System.Xml;
using System.Xml.Linq;

namespace SolutionWalker.FileData;

internal class VisualStudioSolutionHelpers
{
    VisualStudioProjectHelpers projectHelpers = new();

    public SolutionFile Parse(string filePath)
    {
        string[] validExtensions = { ".sln", ".slnx" };
        string extension = Path.GetExtension(filePath).ToLower() ?? "";
        if (!validExtensions.Contains(extension))
        {
            throw new ArgumentException("The specified file is not a Visual Studio solution file.", nameof(filePath));
        }

        SolutionFile solutionFile = new SolutionFile();
        solutionFile.SolutionType = "Visual Studio";
        // File path is unique to solution
        solutionFile.Id = filePath;
        solutionFile.FilePath = filePath;
        solutionFile.Name = Path.GetFileName(filePath);
        var solutionFolder = Path.GetDirectoryName(solutionFile.FilePath);
        if (solutionFolder == null)
        {
            throw new Exception("Could not determine solution folder from solution file path.");
        }

        if (extension == ".slnx")
        {
            var slnxDoc = new XmlDocument();
            slnxDoc.Load(filePath);
            var elements = slnxDoc.DocumentElement.GetElementsByTagName("Project");
            foreach (XmlElement element in elements)
            {
                var elemPath = element.Attributes["Path"]?.Value ?? "";
                var projectFilePath = IOHelpers.CombineToNormalizedPath(solutionFolder, elemPath);
                try
                {
                    var projectFile = projectHelpers.Parse(projectFilePath);
                    solutionFile.ProjectFiles.Add(projectFile);
                }
                catch
                {
                    // TODO: Raise event
                }

            }
        }
        else
        {
            string text = File.ReadAllText(filePath);
            var lines = text.Trim().Split(Environment.NewLine);
            foreach (var line in lines)
            {
                if (line.Starts("Microsoft Visual Studio Solution File"))
                {
                    solutionFile.VisualStudioFormatVersion = line.GetLastSegment();
                }
                if (line.Has("Visual Studio Version")
                    || line.StartsWith("VisualStudioVersion", StringComparison.OrdinalIgnoreCase))
                {
                    solutionFile.VisualStudioSolutionFileVersion = line.GetLastSegment();
                }
                if (line.Starts("MinimumVisualStudioVersion"))
                {
                    solutionFile.MinimumVisualStudioVersion = line.GetLastSegment();
                }
                if (line.Starts("Project"))
                {
                    var projectParts = line.GetProjectParts();
                    var projectFilePath = IOHelpers.CombineToNormalizedPath(solutionFolder, projectParts.ProjectFilePath);
                    try
                    {
                        var projectFile = projectHelpers.Parse(projectFilePath);
                        solutionFile.ProjectFiles.Add(projectFile);
                    }
                    catch
                    {
                        // TODO: Raise event
                    }
                }
            }

        }
        return solutionFile;

    }
}
