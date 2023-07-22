namespace ECom.Domain.EfAbstractions;

public record DbActionResult(bool Status, bool IsRollback, int AffectedRows, Exception? Exception);