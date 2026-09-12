namespace SolutionWalker.Domain.Models;

public record Project : ProjectProperties
{
    public virtual List<Solution> Solutions { get; set; } = null!;
    public virtual List<Reference> References { get; set; } = null!;

    /// <summary>
    /// ONLY available client side so must <c>ToList()</c> first, e.g.
    /// <c>var x = db.Projects.ToList().Where(p => p.ProjectReferences.Any());</c>
    /// </summary>
    public List<Reference> ProjectReferences => References.Where(a => a.ReferenceType == "Project").ToList();
    /// <summary>
    /// ONLY available client side so must <c>ToList()</c> first, e.g.
    /// <c>var x = db.Projects.ToList().Where(p => p.ProjectReferences.Any());</c>
    /// </summary>
    public List<Reference> PackageReferences => References.Where(a => a.ReferenceType == "Package").ToList();
    /// <summary>
    /// ONLY available client side so must <c>ToList()</c> first, e.g.
    /// <c>var x = db.Projects.ToList().Where(p => p.ProjectReferences.Any());</c>
    /// </summary>
    public List<Reference> SystemReferences => References.Where(a => a.ReferenceType == "System").ToList();
}