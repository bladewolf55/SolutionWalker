namespace SolutionWalkerWinform;

public class AppSettings
{
    public const string SqliteDatabaseFileName = "SolutionWalker.db";
    public static string GetSqliteDatabaseFilePath() => Path.Combine(Properties.Settings.Default.SqliteDatabaseFolder, AppSettings.SqliteDatabaseFileName);

}
