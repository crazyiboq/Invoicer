using Invoicer_API.Models;

namespace Invoicer_API.Services;

public interface IInvoiceService
{
    Task<Invoice> CreateInvoice();

    Task<Invoice> EditInvoice(Invoice editedInvoice);

    Task<Invoice> ChangeInvoiceStatus();
    Task<Invoice> DeleteInvoice();
    Task<Invoice> ArchiveInvoice();

    Task<Invoice> GetInvoiceList();
    Task<IEnumerable<Invoice>> GetInvoiceById();



    




}
