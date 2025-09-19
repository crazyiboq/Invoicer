 namespace Invoicer_API.Models;

public class InvoiceRow
{
    public Guid Id { get; set; }

    public Guid InvoiceId { get; set; }

    public string Service { get; set; }

    public decimal Quanity { get; set; }

    public decimal Amount { get; set; }

    public decimal Sum { get; set; }


}
