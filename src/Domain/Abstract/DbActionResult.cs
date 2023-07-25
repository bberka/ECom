namespace ECom.Domain.Abstract;

public record DbActionResult(bool Status, bool IsRollback, int AffectedRows, Exception? Exception);