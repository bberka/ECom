namespace ECom.Domain.DTOs.StockChangeDTOs
{
    public class AddStockChangeRequest
    {
        /// <summary>
        /// 0: Decrease
        /// 1: Add
        /// </summary>
        public bool Type { get; set; }
        public int Count { get; set; }
        public int Cost { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public string? Reason { get; set; }
    }
}