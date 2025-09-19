namespace Invoicer_API.DTOs;

public class 
    CreateInvoiceRequest
{
    public Guid CustomerId { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public List<CreateInvoiceRowDto> Rows { get; set; } = new();
    public string? Comment { get; set; }
}

