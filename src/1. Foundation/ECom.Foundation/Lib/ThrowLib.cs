namespace ECom.Foundation.Lib;

public static class ThrowLib
{
  public static void New(string message) {
    throw new Exception(message);
  }

  public static void New(string message, Exception exception) {
    throw new Exception(message, exception);
  }

  public static void InvalidOperation(string message) {
    throw new InvalidOperationException(message);
  }

  public static void NullReference(string propName) {
    throw new NullReferenceException($"{propName} is null");
  }

  public static void NotImplemented(string message) {
    throw new NotImplementedException(message);
  }

  public static void NotImplemented() {
    throw new NotImplementedException();
  }
}