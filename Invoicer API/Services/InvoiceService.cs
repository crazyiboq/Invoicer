using Invoicer_API.Data;
using Invoicer_API.Models;
using Invoicer_API.DTOs;
using Invoicer_API.Enums;

namespace Invoicer_API.Services;

public class InvoiceService : IInvoiceService
{
    private readonly AppDbContext _dbContext;

    public InvoiceService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Invoice> ArchiveInvoiceAsync(Guid invoiceId)
    {
        throw new NotImplementedException();
    }

    public Task<Invoice> ChangeInvoiceStatusAsync(Guid invoiceId, InvoiceStatus newStatus)
    {
        throw new NotImplementedException();
    }

    public async Task<Invoice> CreateInvoiceAsync(CreateInvoiceRequest request)
    {

        if (request.StartDate > request.EndDate)
            throw new ArgumentException("StartDate cannot be later than EndDate.");

        if (request.Rows == null || !request.Rows.Any())
            throw new ArgumentException("Invoice must contain at least one row.");

        var invoiceRows = request.Rows.Select(row => new InvoiceRow
        {
            Id = Guid.NewGuid(),
            InvoiceId = Guid.Empty,
            Service = row.Service,
            Quantity = row.Quantity,
            Amount = row.Amount
        }).ToList();

        var invoice = new Invoice
        {
            Id = Guid.NewGuid(),
            CustomerId = request.CustomerId,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Rows = invoiceRows,
            Comment = request.Comment,
            Status = InvoiceStatus.Created,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow,
            DeletedAt = null
        };

        foreach (var row in invoice.Rows)
        {
            row.InvoiceId = invoice.Id;
        }

        _dbContext.Invoices.Add(invoice);
        await _dbContext.SaveChangesAsync();

        return invoice;
    }

    public Task<bool> DeleteInvoiceAsync(Guid invoiceId)
    {
        throw new NotImplementedException();
    }

    public Task<Invoice> EditInvoiceAsync(Invoice editedInvoice)
    {
        throw new NotImplementedException();
    }

    public Task<Invoice?> GetInvoiceByIdAsync(Guid invoiceId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Invoice>> GetInvoiceListAsync()
    {
        throw new NotImplementedException();
    }
}
