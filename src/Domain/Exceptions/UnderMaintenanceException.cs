namespace ECom.Domain.Exceptions;

public class UnderMaintenanceException : CustomException
{
  public UnderMaintenanceException() : base("UnderMaintenance") {
  }
}