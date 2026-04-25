using LinqToDB;

namespace IPmcp.Database.Extensions;

public static class PostgreSqlExtensions
{
    [Sql.Expression(
        "(to_tsvector('russian', {0}) || to_tsvector('english', {0})) @@ (websearch_to_tsquery('russian', {1}) || websearch_to_tsquery('english', {1}))",
        ServerSideOnly = true, IsPredicate = true)]
    public static bool MatchesText(this string? field, string pattern)
        => throw new InvalidOperationException("Server-side only");
}
