namespace ECom.Domain.Exceptions;

public class ActionFailedException : CustomException
{
  public ActionFailedException(string actionName) : base(actionName) {
  }
}