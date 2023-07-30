namespace ECom.Shared.Abstract;

public record DbActionResult(bool Status, bool IsRollback, int AffectedRows, Exception? Exception);