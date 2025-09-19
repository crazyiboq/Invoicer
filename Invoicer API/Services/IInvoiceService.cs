using Invoicer_API.DTOs;
using Invoicer_API.Enums;
using Invoicer_API.Models;

namespace Invoicer_API.Services;

public interface IInvoiceService
{
    Task<Invoice> CreateInvoiceAsync(CreateInvoiceRequest request);

    Task<Invoice> EditInvoiceAsync(Invoice editedInvoice);

    Task<Invoice> ChangeInvoiceStatusAsync(Guid invoiceId, InvoiceStatus newStatus);

    Task<bool> DeleteInvoiceAsync(Guid invoiceId);

    Task<Invoice> ArchiveInvoiceAsync(Guid invoiceId);

    Task<IEnumerable<Invoice>> GetInvoiceListAsync();

    Task<Invoice?> GetInvoiceByIdAsync(Guid invoiceId);








}
