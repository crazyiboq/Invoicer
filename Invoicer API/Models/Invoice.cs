using Invoicer_API.Entity;
using Invoicer_API.Enums;

namespace Invoicer_API.Models;

public class Invoice : BaseEntity
{

    public Guid CustomerId { get; set; }

    public DateTimeOffset StartDate { get; set; }
    
    public DateTimeOffset EndDate { get; set; }

    public decimal TotalSum { get; set; }

    public InvoiceRow[] Rows { get; set; }

    public string? Comment { get; set; }

    public InvoiceStatus Status { get; set; }

    







}
