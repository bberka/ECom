namespace ECom.Shared.DTOs;

public class Statistics
{
  public float TodaySalesMoney { get; set; } = 0;
  public long TodaySalesCount { get; set; } = 0;
  public float ThisWeekSalesMoney { get; set; } = 0;
  public long ThisWeekSalesCount { get; set; } = 0;
  public float ThisMonthSalesMoney { get; set; } = 0;
  public long ThisMonthSalesCount { get; set; } = 0;
  public float TotalSalesMoney { get; set; } = 0;
  public long TotalSalesCount { get; set; } = 0;
}