namespace ECom.Foundation.Exceptions;

public class ActionFailedException : CustomException
{
  public ActionFailedException(string actionName) : base(actionName) { }
}