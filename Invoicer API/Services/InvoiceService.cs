using Invoicer_API.Data;
using Invoicer_API.DTOs;
using Invoicer_API.Enums;
using Invoicer_API.Models;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Invoice> ChangeInvoiceStatusAsync(Guid invoiceId, InvoiceStatus newStatus)
    {
        var invoice = await _dbContext.Invoices
                            .FirstOrDefaultAsync(i => i.Id == invoiceId);

        if (invoice == null)
            throw new KeyNotFoundException($"Invoice with ID {invoiceId} not found.");


        invoice.Status = newStatus;

        await _dbContext.SaveChangesAsync();

        return invoice;
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

    public async Task<bool> DeleteInvoiceAsync(Guid invoiceId)
    {
        var invoice = await _dbContext.Invoices.FindAsync(invoiceId);

        if (invoice == null)
            return false;

        _dbContext.Invoices.Remove(invoice);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public Task<Invoice> EditInvoiceAsync(Invoice editedInvoice)
    {
        throw new NotImplementedException();
    }

    public async Task<Invoice?> GetInvoiceByIdAsync(Guid invoiceId)
    {
        return await _dbContext.Invoices
            .Include(i => i.Rows)
            .FirstOrDefaultAsync(i => i.Id == invoiceId);
    }


    public async Task<IEnumerable<Invoice>> GetInvoiceListAsync()
    {
        return await _dbContext.Invoices
            .Include(i => i.Rows)
            .ToListAsync();
    }
}
