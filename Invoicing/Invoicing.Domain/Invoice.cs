namespace Invoicing.Domain
{
    public class Invoice : BaseEntity
    {
        public string? Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal TotalAmount { get; set; }
        public List<InvoiceLine> InvoiceLines { get; set; }
    }
}
